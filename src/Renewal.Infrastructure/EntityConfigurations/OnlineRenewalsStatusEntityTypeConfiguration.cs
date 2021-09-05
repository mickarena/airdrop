using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renewal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Renewal.Infrastructure.EntityConfigurations
{
    public class OnlineRenewalsStatusEntityTypeConfiguration : IEntityTypeConfiguration<OnlineRenewalsStatus>
    {
        public void Configure(EntityTypeBuilder<OnlineRenewalsStatus> builder)
        {
            builder.ToTable("OnlineRenewalsStatus");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .HasMaxLength(50);
        }
    }
}
