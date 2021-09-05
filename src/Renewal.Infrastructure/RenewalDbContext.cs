using Microsoft.EntityFrameworkCore;
using Renewal.Domain.Entities;
using Renewal.Infrastructure.EntityConfigurations;

namespace Renewal.Infrastructure
{
    public class RenewalDbContext : DbContext
    {
        public RenewalDbContext(DbContextOptions<RenewalDbContext> options) : base(options) { }

        public DbSet<RenewalProcessing> OnlineRenewalsProcessingData { set; get; }

        public DbSet<OnlineRenewalsStatus> OnlineRenewalsStatus { set; get; }

        public DbSet<RenewalInvites> RenewalInvites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RenewalProcessingDataEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RenewalInvitesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OnlineRenewalsStatusEntityTypeConfiguration());
        }

    }
}
