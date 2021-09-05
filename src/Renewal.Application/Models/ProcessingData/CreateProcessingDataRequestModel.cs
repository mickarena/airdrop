using System;

namespace Renewal.Application.Models.ProcessingData
{
    public class CreateProcessingDataRequestModel
    {
        public int Id { get; set; }
        public decimal PolicyId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDateCreated { set; get; }
        public decimal? Deposit { get; set; }
        public decimal? Instalments { get; set; }
        public decimal? TotalPayment { get; set; }
        public string TransactionId { get; set; }
        public int ClientNumber { get; set; }
        public short PolicyLine { get; set; }
        public int? Status { get; set; }
        public DateTime? StatusTimeStamp { get; set; }
        public string Prefix { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string EmailAddress { get; set; }
        public string EmailSentTimeStamp { get; set; }
        public string Comment { get; set; }
        public string EncBankAccountName { get; set; }
        public string EncBankAccountNumber { get; set; }
        public string EncSortCode { get; set; }
        public string PolicyType { get; set; }
        public DateTime? RenewalDate { get; set; }
        public bool? PaperDocs { get; set; }
        public bool? Cpa { get; set; }
        public string CompanyCode { get; set; }
        public string BrandCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool Transferred { set; get; }
    }
}
