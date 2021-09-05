using Renewal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Renewal.Domain.Repositories
{
    public interface IRenewalInvitesRepository : IRepository<RenewalInvites>
    {
        Task<RenewalInvites> GetByPolicyReferenceNumberAsync(string policyReferenceNumber);
    }
}
