using AutoMapper;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.Models.Client;
using Renewal.Application.Models.OnlineRenewalsStatus;
using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.Infrastructure.DatabaseServices
{
    public class OnlineRenewalsStatusService : IOnlineRenewalsStatusService
    {
        private readonly IOnlineRenewalsStatusRepository _onlineRenewalsStatusRepository;
        private readonly IMapper _mapper;

        public OnlineRenewalsStatusService(IOnlineRenewalsStatusRepository onlineRenewalsStatusRepository, IMapper mapper)
        {
            _onlineRenewalsStatusRepository = onlineRenewalsStatusRepository;
            _mapper = mapper;
        }

        public async Task<OnlineRenewalsStatusResponseModel> GetStatusByName(string  statusName)
        {
            var deails = _onlineRenewalsStatusRepository.Find(p=>p.Text.Equals(statusName)).FirstOrDefault();
            var data = _mapper.Map<OnlineRenewalsStatusResponseModel>(deails);
            return data;
        }
    }
}
