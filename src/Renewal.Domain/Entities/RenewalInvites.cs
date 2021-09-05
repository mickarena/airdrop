using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Domain.Entities
{
    public class RenewalInvites
    {
        public string PolicyReference { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Email { get; set; }
        public string PostCode { get; set; }
        public short PolicyLine { get; set; }
        public string PolicyType { get; set; }
        public int TotalPremiumPIF { get; set; }
        public byte NumberInstalments { get; set; }
        public int MonthlyPayment { get; set; }
        public int Deposit { get; set; }
        public int FinanceCharge { get; set; }
        public int TotalPremiumDD { get; set; }
        public int APR { get; set; }
        public int InterestRate { get; set; }
        public string CompanyCode { get; set; }
        public DateTime RenewalDate { get; set; }
        public string VehicleRegistration { get; set; }
        public string PolicyStatus { get; set; }
        public string AffinityCode { get; set; }
        public string BrandCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public byte? BookOnLine { get; set; }
        public string RenewalLetterRef { get; set; }
        public string Prefix { get; set; }
    }
}
