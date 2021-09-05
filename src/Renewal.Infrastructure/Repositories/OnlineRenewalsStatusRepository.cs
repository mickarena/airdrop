using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;

namespace Renewal.Infrastructure.Repositories
{
    public class OnlineRenewalsStatusRepository : Repository<OnlineRenewalsStatus>, IOnlineRenewalsStatusRepository
    {
        public OnlineRenewalsStatusRepository(RenewalDbContext context) : base(context)
        { }
    }
}
