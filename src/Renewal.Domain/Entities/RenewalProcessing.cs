using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Domain.Entities
{
    public class RenewalProcessing
    {
        public Guid Id { get; set; }
        public string PolicyReference { get; set; }
        public string PaymentMethod { get; set; }
        public int Deposit { get; set; }
        public int TotalPremiumPIF { get; set; }
        public byte NumberInstalments { get; set; }
        public int MonthlyPayment { get; set; }
        public int FinanceCharge { get; set; }
        public int TotalPremiumDD { get; set; }
        public int APR { get; set; }
        public int InterestRate { get; set; }
        public string PaymentTransactionId { get; set; }
        public short PolicyLine { get; set; }
        public string PolicyStatus { get; set; }
        public int? RenewalProcessStatus { get; set; }
        public DateTime? RenewalProcessStatusDate { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string VehicleRegistration { get; set; }
        public string EncryptedAccountHolder { get; set; }
        public string EncryptedBankAccountNumber { get; set; }
        public string EncryptedBankSortCode { get; set; }
        public string BankName { get; set; }
        public string PolicyType { get; set; }
        public string AffinityCode { get; set; }
        public DateTime? RenewalDate { get; set; }
        public bool? EmailDocuments { get; set; }
        public bool? StatementofFactConfirmed { get; set; }
        public bool? CPAAuthorisation { get; set; }
        public bool? DirectDebitReadConfirmation { get; set; }
        public bool? DirectDebitRepaymentConfirmation { get; set; }
        public string CompanyCode { get; set; }
        public string BrandCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public byte? BookOnLine { get; set; }
        public DateTime? PaymentDateCreated { get; set; }
        public int? TotalPayment { get; set; }
        public string RenewalLetterRef { get; set; }
        public string Prefix { get; set; }
        public DateTime? DataTransferDate { get; set; }
    }
}
