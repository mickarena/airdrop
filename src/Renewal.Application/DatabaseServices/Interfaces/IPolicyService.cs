using Renewal.Application.Models.Financial;
using Renewal.Application.ResultObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renewal.Application.DatabaseServices.Interfaces
{
    public interface IPolicyService
    {
        Task<AbstractResult<FinancialResponseModel>> GetFinancialByPolicyRef(string policyRefer);
    }
}
