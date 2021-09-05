using Renewal.Application.Models.ProcessingData;
using Renewal.Application.ResultObjects;
using System.Threading.Tasks;

namespace Renewal.Application.DatabaseServices.Interfaces
{
    public interface IProcessingDataService
    {
        Task<AbstractResult<ProcessingDataResponseModel>> Verification(VerificationQuestionRequestModel model);
        Task<AbstractResult<bool>> UpdateStatus(UpdateStatusRequestModel model);
        Task<AbstractResult<bool>> UpdateTransactionAsync(UpdatePaymentTransactionRequestModel model);
        Task<AbstractResult<bool>> UpdatePaymentMethodAsync(UpdatePaymentMethodRequestModel model);
        Task<AbstractResult<bool>> UpdateBankAccountAsync(UpdateBankAccountRequestModel model);
        Task<AbstractResult<bool>> VerifyPaymentInforAsync(VerifyPaymentInforRequestModel model);
    }
}
