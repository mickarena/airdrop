using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renewal.Domain.Entities;

namespace Renewal.Infrastructure.EntityConfigurations
{
    public class RenewalInvitesEntityTypeConfiguration : IEntityTypeConfiguration<RenewalInvites>
    {
        public void Configure(EntityTypeBuilder<RenewalInvites> builder)
        {
            builder.ToTable("RenewalInvites");
            builder.HasKey(x => x.PolicyReference);

            builder.Property(x => x.PolicyReference)
                .IsUnicode(false)
                .HasMaxLength(50)
                .ValueGeneratedNever();

            builder.Property(x => x.Forename)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.Surname)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.DateofBirth)
                .HasColumnType("Date")
                .IsRequired(true);

            builder.Property(x => x.AddressLine1)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine2)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine3)
                .HasColumnName("AddressLine3")
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine4)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsUnicode(false)
                .HasMaxLength(320);

            builder.Property(x => x.PostCode)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(9);

            builder.Property(x => x.PolicyLine)
               .HasColumnType("smallint");

            builder.Property(x => x.PolicyType)
                .IsUnicode(false)
                .IsRequired(true)
                .HasMaxLength(2);

            builder.Property(x => x.NumberInstalments)
               .HasColumnType("tinyint");

            builder.Property(x => x.CompanyCode)
                 .IsRequired(false)
                 .IsUnicode(false)
                 .HasMaxLength(2);

            builder.Property(x => x.RenewalDate)
                .IsRequired(true)
                .HasColumnType("Date");

            builder.Property(x => x.VehicleRegistration)
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(x => x.PolicyStatus)
               .IsRequired(false)
               .IsUnicode(false)
               .HasMaxLength(2);

            builder.Property(x => x.AffinityCode)
                .IsUnicode(false)
                .IsRequired(false)
                .HasMaxLength(4);

            builder.Property(x => x.BrandCode)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(2);

            builder.Property(x => x.DateCreated)
              .HasColumnType("DateTime")
              .IsRequired(false);

            builder.Property(x => x.BookOnLine)
               .HasColumnType("tinyint")
               .IsRequired(false);

            builder.Property(x => x.RenewalLetterRef)
               .IsRequired(true)
               .IsUnicode(false)
               .HasMaxLength(50);

            builder.Property(x => x.Prefix)
                .IsUnicode(false)
                .HasMaxLength(8);
        }
    }
}
