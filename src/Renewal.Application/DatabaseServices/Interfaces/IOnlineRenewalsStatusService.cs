using Renewal.Application.Models.OnlineRenewalsStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Application.DatabaseServices.Interfaces
{
    public interface IOnlineRenewalsStatusService
    {
        Task<OnlineRenewalsStatusResponseModel> GetStatusByName(string statusName);
    }
}
