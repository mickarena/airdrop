using AutoMapper;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Application.ExtensionService.IService;
using Renewal.Application.Models.Financial;
using Renewal.Application.ResultObjects;
using Renewal.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.Infrastructure.DatabaseServices
{
    public class PolicyService : IPolicyService
    {
        private readonly IRenewalInvitesRepository _policyRepository;
        private readonly IMapper _mapper;
        private readonly IResourceDataService _resourceDataService;

        public PolicyService(IRenewalInvitesRepository policyRepository, IMapper mapper, IResourceDataService resourceDataService)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
            _resourceDataService = resourceDataService;
        }

        public async Task<AbstractResult<FinancialResponseModel>> GetFinancialByPolicyRef(string policyRef)
        {
            var query = await _policyRepository.GetByPolicyReferenceNumberAsync(policyRef);
            if (query == null)
            {
                return new AppErrorResult<FinancialResponseModel>(null, _resourceDataService.GetValue("Financial_Not_Found"));
            }
            var respone = _mapper.Map<FinancialResponseModel>(query);
            return new AppSuccessResult<FinancialResponseModel>(respone, _resourceDataService.GetValue("Financial_Successfully"));
        }
    }
}
