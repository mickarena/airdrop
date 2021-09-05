using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Renewal.Domain.Entities;

namespace Renewal.Infrastructure.EntityConfigurations
{
    public class RenewalProcessingDataEntityTypeConfiguration : IEntityTypeConfiguration<RenewalProcessing>
    {
        public void Configure(EntityTypeBuilder<RenewalProcessing> builder)
        {
            builder.ToTable("RenewalProcessing");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.PolicyReference)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.PaymentMethod)
             .IsUnicode(false)
             .HasMaxLength(12);

            builder.Property(x => x.Deposit)
             .IsRequired(true);

            builder.Property(x => x.TotalPremiumPIF)
             .IsRequired(true);

            builder.Property(x => x.NumberInstalments)
             .IsRequired(true);

            builder.Property(x => x.MonthlyPayment)
             .IsRequired(true);

            builder.Property(x => x.FinanceCharge)
             .IsRequired(true);

            builder.Property(x => x.TotalPremiumDD)
             .IsRequired(true);

            builder.Property(x => x.APR)
             .IsRequired(true);

            builder.Property(x => x.InterestRate)
             .IsRequired(true);

            builder.Property(x => x.PaymentTransactionId)
             .IsUnicode(false)
             .HasMaxLength(50);

            builder.Property(x => x.PolicyLine)
               .HasColumnType("smallint");

            builder.Property(x => x.PolicyStatus)
               .IsUnicode(false)
               .HasMaxLength(2);

            builder.Property(x => x.RenewalProcessStatus);

            builder.Property(x => x.Forename)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.Surname)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.RenewalProcessStatusDate)
                .HasColumnType("datetime");

            builder.Property(x => x.DateOfBirth)
                .IsRequired(true)
                .HasColumnType("datetime");

            builder.Property(x => x.AddressLine1)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine2)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine3)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.AddressLine4)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.PostCode)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(9);

            builder.Property(x => x.Email)
                .IsUnicode(false)
                .HasMaxLength(320);

            builder.Property(x => x.EncryptedAccountHolder)
                .HasColumnName("EncryptedAccountHolder")
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(x => x.EncryptedBankAccountNumber)
                .HasColumnName("EncryptedBankAccountNumber")
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(x => x.EncryptedBankSortCode)
                .HasColumnName("EncryptedBankSortCode")
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(x => x.VehicleRegistration)
                .IsUnicode(false)
                .HasMaxLength(10);

            builder.Property(x => x.BankName)
                .IsUnicode(false);

            builder.Property(x => x.PolicyType)
                .IsUnicode(false)
                .IsRequired(true)
                .HasMaxLength(2);

            builder.Property(x => x.AffinityCode)
                .IsUnicode(false)
                .HasMaxLength(4);

            builder.Property(x => x.RenewalDate)
                .HasColumnType("Date");

            builder.Property(x => x.CompanyCode)
                 .IsUnicode(false)
                 .HasMaxLength(2);

            builder.Property(x => x.BrandCode)
                 .IsUnicode(false)
                 .HasMaxLength(2);

            builder.Property(x => x.DateCreated)
                 .HasColumnType("datetime");

            builder.Property(x => x.BookOnLine)
               .IsUnicode(false)
               .HasColumnType("tinyint");

            builder.Property(x => x.PaymentDateCreated)
                 .HasColumnType("datetime");

            builder.Property(x => x.TotalPayment);

            builder.Property(x => x.RenewalLetterRef)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.Prefix)
                .IsUnicode(false)
                .HasMaxLength(8);

            builder.Property(x => x.DataTransferDate)
                 .HasColumnType("datetime");
        }
    }
}
