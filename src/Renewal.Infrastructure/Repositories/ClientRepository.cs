using Renewal.Domain.Entities;
using Renewal.Domain.Repositories;

namespace Renewal.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(RenewalDbContext context) : base(context)
        { }
    }
}
