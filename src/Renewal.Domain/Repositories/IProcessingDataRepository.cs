using Renewal.Domain.Entities;
using System.Threading.Tasks;

namespace Renewal.Domain.Repositories
{
    public interface IProcessingDataRepository : IRepository<RenewalProcessing>
    {
        Task<RenewalProcessing> SaveAsync(RenewalProcessing model);
        Task<bool> UpdateAsync(RenewalProcessing model);

        Task<bool> UpdateStatusAsync(RenewalProcessing model);
        Task<bool> UpdateTransactionAsync(RenewalProcessing model);
        Task<bool> UpdatePaymentMethodAsync(RenewalProcessing model);
        Task<bool> UpdateBankAccountAsync(RenewalProcessing model);
        Task<RenewalProcessing> GetProcessingByPolicyRef(string PolicyReference);
    }
}
