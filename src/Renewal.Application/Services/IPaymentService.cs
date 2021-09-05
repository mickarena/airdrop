using System.Threading.Tasks;
using Renewal.Application.ResultObjects;

namespace Renewal.Application.Services
{
    public interface IPaymentService
    {
        Task<AbstractResult<bool>> GetIsLockPayment(string policyReferenceNumber);
    }
}