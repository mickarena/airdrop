using Microsoft.EntityFrameworkCore;
using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Renewal.Infrastructure.Repositories
{
    public class RenewalInvitesRepository : Repository<RenewalInvites>, IRenewalInvitesRepository
    {

        public RenewalInvitesRepository(RenewalDbContext context) : base(context)
        {
        }

        public async Task<RenewalInvites> GetByPolicyReferenceNumberAsync(string policyReferenceNumber)
        {
            var policyDetail = await base._context.RenewalInvites.AsNoTracking().FirstOrDefaultAsync(p => p.PolicyReference == policyReferenceNumber);
            return policyDetail;
        }
    }
}
