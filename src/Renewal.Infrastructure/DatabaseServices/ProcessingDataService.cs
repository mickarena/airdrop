using AutoMapper;
using Microsoft.Extensions.Options;
using Renewal.Application.Common;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.ExtensionService.IService;
using Renewal.Application.Models.ProcessingData;
using Renewal.Application.ResultObjects;
using Renewal.Application.Services;
using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Renewal.Infrastructure.DatabaseServices
{
    public class ProcessingDataService : IProcessingDataService
    {
        private readonly IProcessingDataRepository _processingDataRepository;
        private readonly IOnlineRenewalsStatusRepository _onlineRenewalsStatusRepository;
        private readonly IRenewalInvitesRepository _policyRepository;
        private readonly IMapper _mapper;
        private readonly IResourceDataService _resourceDataService;
        private readonly IPaymentService _paymentService;
        IOptions<AppSettingsConfiguration> _config;

        public ProcessingDataService(
            IOptions<AppSettingsConfiguration> config,
            IMapper mapper,
            IRenewalInvitesRepository policyRepository,
            IOnlineRenewalsStatusRepository onlineRenewalsStatusRepository,
            IProcessingDataRepository processingDataRepository,
            IResourceDataService resourceDataService,
            IPaymentService paymentService)
        {
            _mapper = mapper;
            _policyRepository = policyRepository;
            _onlineRenewalsStatusRepository = onlineRenewalsStatusRepository;
            _processingDataRepository = processingDataRepository;
            _resourceDataService = resourceDataService;
            _paymentService = paymentService;
            _config = config;
        }

        public async Task<AbstractResult<ProcessingDataResponseModel>> Verification(VerificationQuestionRequestModel model)
        {
            var renewalPolicyDetails = await _policyRepository.GetByPolicyReferenceNumberAsync(model.PolicyReference);
            var processingData = await _processingDataRepository.GetProcessingByPolicyRef(model.PolicyReference);

            if (renewalPolicyDetails == null)
            {
                return new AppErrorResult<ProcessingDataResponseModel>(null, _resourceDataService.GetValue("Verification_Reference_Number_Invalid"));
            }

            if (!renewalPolicyDetails.Forename[0].Equals(model.FirstNames[0]))
            {
                return new AppErrorResult<ProcessingDataResponseModel>(null, _resourceDataService.GetValue("Verification_FirstName_Invalid"));
            }

            if (!string.Equals(renewalPolicyDetails.Surname, model.Surname, StringComparison.OrdinalIgnoreCase))
            {
                return new AppErrorResult<ProcessingDataResponseModel>(null, _resourceDataService.GetValue("Verification_Surname_Invalid"));
            }

            if (((DateTime)renewalPolicyDetails.DateofBirth).Date != ((DateTime)model.BirthDate).Date)
            {
                return new AppErrorResult<ProcessingDataResponseModel>(null, _resourceDataService.GetValue("Verification_BirthDate_Invalid"));
            }

            //map data from UI
            renewalPolicyDetails.Forename = model.FirstNames;
            renewalPolicyDetails.Email = model.EmailAddress;
            var data = _mapper.Map<RenewalProcessing>(renewalPolicyDetails);
            var entity = new RenewalProcessing();
            if (processingData != null)
            {
                data.Id = processingData.Id;
                data.RenewalProcessStatus = processingData.RenewalProcessStatus;
                await _processingDataRepository.UpdateAsync(data);
                var isLock = await _paymentService.GetIsLockPayment(model.PolicyReference);
                var url = RedirectWithStatus(processingData.RenewalProcessStatus.ToString(), isLock.ResultObj);
                var response = new ProcessingDataResponseModel() { Id = processingData.Id ,Url = url, PolicyType = data.PolicyType };
                return new AppSuccessResult<ProcessingDataResponseModel>(response, _resourceDataService.GetValue("Verification_Successfully"));
            }
            else
            {
                entity = await _processingDataRepository.SaveAsync(data);
            }
            var respone = new ProcessingDataResponseModel() { Id = entity.Id, Url = "PaymentOptions", PolicyType = data.PolicyType };
            return new AppSuccessResult<ProcessingDataResponseModel>(respone, _resourceDataService.GetValue("Verification_Successfully"));
        }

        public async Task<AbstractResult<bool>> UpdateStatus(UpdateStatusRequestModel model)
        {
            var status = _onlineRenewalsStatusRepository.Find(p => p.Text.Equals(model.RenewalProcessStatus)).FirstOrDefault();
            if (status == null)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Status_Error"));
            }

            var data = new RenewalProcessing()
            {
                PolicyReference = model.PolicyReference,
                RenewalProcessStatusDate = model.RenewalProcessStatusDate,
                RenewalProcessStatus = status.Id
            };

            var success = await _processingDataRepository.UpdateStatusAsync(data);

            if (!success)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Status_Error"));
            }

            return new AppSuccessResult<bool>(true, _resourceDataService.GetValue("ProcessingData_Update_Status_Success"));
        }

        public async Task<AbstractResult<bool>> UpdateTransactionAsync(UpdatePaymentTransactionRequestModel model)
        {
            var status = new OnlineRenewalsStatus();
            if (model.RenewalProcessStatus == Constants.PaymentStatus.KeepCurrentStatus)
            {
                status = null;
            }
            else
            {
                status = _onlineRenewalsStatusRepository.Find(p => p.Text.Equals(model.RenewalProcessStatus)).FirstOrDefault();
                if (status == null)
                {
                    return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Transaction_Error"));
                }
            }
            var data = new RenewalProcessing()
            {
                PolicyReference = model.PolicyReference,
                RenewalProcessStatusDate = model.RenewalProcessStatusDate,
                PaymentTransactionId = model.PaymentTransactionId,
                RenewalProcessStatus = status != null ? status.Id : (int?)null,
                TotalPayment = model.AmountPaid != null ? Convert.ToInt32(model.AmountPaid) : (int?)null,
                PaymentDateCreated = model.PaymentDateCreated
            };
            var success = await _processingDataRepository.UpdateTransactionAsync(data);

            if (!success)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Transaction_Error"));
            }

            return new AppSuccessResult<bool>(true, _resourceDataService.GetValue("ProcessingData_Update_Transaction_Success"));
        }

        public async Task<AbstractResult<bool>> UpdatePaymentMethodAsync(UpdatePaymentMethodRequestModel model)
        {
            var data = new RenewalProcessing()
            {
                PolicyReference = model.PolicyReference,
                StatementofFactConfirmed = model.StatementofFactConfirmed,
                EmailDocuments = model.EmailDocuments,
                CPAAuthorisation = model.CPAAuthorisation,
                PaymentMethod = model.PaymentMethod
            };
            var success = await _processingDataRepository.UpdatePaymentMethodAsync(data);

            if (!success)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Payment_Method_Error"));
            }

            return new AppSuccessResult<bool>(true, _resourceDataService.GetValue("ProcessingData_Update_Payment_Method_Success"));
        }

        public async Task<AbstractResult<bool>> UpdateBankAccountAsync(UpdateBankAccountRequestModel model)
        {
            var data = new RenewalProcessing()
            {
                PolicyReference = model.PolicyReference,
                DirectDebitReadConfirmation = model.DirectDebitReadConfirmation,
                DirectDebitRepaymentConfirmation = model.DirectDebitRepaymentConfirmation,
                EncryptedAccountHolder = model.EncryptedAccountHolder,
                EncryptedBankAccountNumber = model.EncryptedBankAccountNumber,
                EncryptedBankSortCode = model.EncryptedBankSortCode,
                BankName = model.BankName
            };
            var success = await _processingDataRepository.UpdateBankAccountAsync(data);

            if (!success)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Update_Bank_Account_Error"));
            }

            return new AppSuccessResult<bool>(true, _resourceDataService.GetValue("ProcessingData_Update_Bank_Account_Success"));
        }

        public string RedirectWithStatus(string status, bool isLock)
        {
            var url = "";

            switch (status)
            {
                case null:
                    url = "PaymentOptions";
                    break;
                case "6":
                    url = "PurchaseFailed";
                    break;
                default:
                    url = isLock ? "PurchaseFailed" : "PaymentOptions";
                    break;
            }

            return url;
        }

        public async Task<AbstractResult<bool>> VerifyPaymentInforAsync(VerifyPaymentInforRequestModel model)
        {
            var processingData = await _processingDataRepository.GetProcessingByPolicyRef(model.PolicyReference);

            if (processingData == null)
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Verify_Payment_Infor_Error"));
            }

            if (!string.IsNullOrEmpty(processingData.PolicyType) && !processingData.PolicyType.Equals(model.PolicyType, StringComparison.InvariantCultureIgnoreCase))
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Verify_Payment_Infor_Error"));
            }

            if (!string.IsNullOrEmpty(processingData.AffinityCode) && !processingData.AffinityCode.Equals(model.AffinityCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return new AppErrorResult<bool>(false, _resourceDataService.GetValue("ProcessingData_Verify_Payment_Infor_Error"));
            }

            return new AppSuccessResult<bool>(true, _resourceDataService.GetValue("ProcessingData_Verify_Payment_Infor_Success"));
        }
    }
}
