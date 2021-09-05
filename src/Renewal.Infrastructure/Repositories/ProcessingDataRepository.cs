using System.Threading.Tasks;
using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Renewal.Infrastructure.Repositories
{
    public class ProcessingDataRepository : Repository<RenewalProcessing>, IProcessingDataRepository
    {
        public ProcessingDataRepository(RenewalDbContext context) : base(context)
        { }

        public async Task<RenewalProcessing> SaveAsync(RenewalProcessing model)
        {
            await base._context.OnlineRenewalsProcessingData.AddAsync(model);
            await base._context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> UpdateAsync(RenewalProcessing model)
        {
            base._context.OnlineRenewalsProcessingData.Update(model);
            return await base._context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStatusAsync(RenewalProcessing model)
        {
            var processingData = await _context.OnlineRenewalsProcessingData.FirstOrDefaultAsync(p => p.PolicyReference == model.PolicyReference);
            if (processingData == null)
            {
                return false;
            }
            else
            {
                processingData.DataTransferDate = processingData.RenewalProcessStatus == model.RenewalProcessStatus ? processingData.DataTransferDate : null;
                processingData.RenewalProcessStatus = model.RenewalProcessStatus;
                processingData.RenewalProcessStatusDate = model.RenewalProcessStatusDate;
                await base._context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateTransactionAsync(RenewalProcessing model)
        {
            var processingData = await _context.OnlineRenewalsProcessingData.FirstOrDefaultAsync(p => p.PolicyReference == model.PolicyReference);
            if (processingData == null)
            {
                return false;
            }
            else
            {
                processingData.PaymentTransactionId = model.PaymentTransactionId;
                if (model.RenewalProcessStatus.HasValue)
                {
                    processingData.DataTransferDate = processingData.RenewalProcessStatus == model.RenewalProcessStatus ? processingData.DataTransferDate  : null;
                    processingData.RenewalProcessStatus = model.RenewalProcessStatus;
                }
                processingData.PolicyReference = model.PolicyReference;
                processingData.RenewalProcessStatusDate = model.RenewalProcessStatusDate;
                processingData.TotalPayment = model.TotalPayment.HasValue ? model.TotalPayment : processingData.TotalPayment;
                processingData.PaymentDateCreated = model.PaymentDateCreated.HasValue ? model.PaymentDateCreated: processingData.PaymentDateCreated;
                await base._context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdatePaymentMethodAsync(RenewalProcessing model)
        {
            var processingData = await _context.OnlineRenewalsProcessingData.FirstOrDefaultAsync(p => p.PolicyReference == model.PolicyReference);
            if (processingData == null)
            {
                return false;
            }
            else
            {
                processingData.PaymentMethod = model.PaymentMethod;
                processingData.EmailDocuments = model.EmailDocuments;
                processingData.StatementofFactConfirmed = model.StatementofFactConfirmed;
                processingData.CPAAuthorisation = model.CPAAuthorisation;

                //reset debit data when back step
                processingData.DirectDebitReadConfirmation = null;
                processingData.DirectDebitRepaymentConfirmation = null;
                processingData.EncryptedBankAccountNumber = null;
                processingData.EncryptedAccountHolder = null;
                processingData.EncryptedBankSortCode = null;
                processingData.BankName = null;

                await base._context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateBankAccountAsync(RenewalProcessing model)
        {
            var processingData = await _context.OnlineRenewalsProcessingData.FirstOrDefaultAsync(p => p.PolicyReference == model.PolicyReference);
            if (processingData == null)
            {
                return false;
            }
            else
            {
                processingData.DirectDebitReadConfirmation = model.DirectDebitReadConfirmation;
                processingData.DirectDebitRepaymentConfirmation = model.DirectDebitRepaymentConfirmation;
                processingData.EncryptedAccountHolder = model.EncryptedAccountHolder;
                processingData.EncryptedBankAccountNumber = model.EncryptedBankAccountNumber;
                processingData.EncryptedBankSortCode = model.EncryptedBankSortCode;
                processingData.BankName = model.BankName;
                await base._context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<RenewalProcessing> GetProcessingByPolicyRef(string policyReference)
        {
            var result = await _context.OnlineRenewalsProcessingData.AsNoTracking().FirstOrDefaultAsync(p => p.PolicyReference.Equals(policyReference));

            return result;
        }
    }
}
