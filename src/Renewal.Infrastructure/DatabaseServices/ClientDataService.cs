using AutoMapper;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.Models.Client;
using Renewal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Infrastructure.DatabaseServices
{
    public class ClientDataService : IClientDataService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientDataService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientResponseModel>> FetchClients()
        {
            var query = _clientRepository.List();
            return _mapper.ProjectTo<ClientResponseModel>(query);
        }

        public Task<ClientDetailsResponseModel> GetClientDetails(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
