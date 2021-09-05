using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Renewal.Application.Models.Client;

namespace Renewal.Application.DatabaseServices.Interfaces
{
    public interface IClientDataService
    {
        Task<ClientDetailsResponseModel> GetClientDetails(int clientId);
        Task<IEnumerable<ClientResponseModel>> FetchClients();
    }
}
