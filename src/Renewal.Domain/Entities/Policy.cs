using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Domain.Entities
{
    public class Policy
    {
        public int PkId { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public int ClientNumber { get; set; }
        public short PolicyLine { get; set; }
        public string PolType { get; set; }
        public decimal Premium { get; set; }
        public string CompanyCode { get; set; }
        public string OptionalExtra1 { get; set; }
        public double? OptionalCost1 { get; set; }
        public string OptionalExtra2 { get; set; }
        public double? OptionalCost2 { get; set; }
        public string OptionalExtra3 { get; set; }
        public double? OptionalCost3 { get; set; }
        public string SchemeCode { get; set; }

        public DateTime? RenewalDate { get; set; }
        public string PolicyDetails { get; set; }
        public string PostCode { get; set; }
        public string PolicyStatus { get; set; }
        public DateTime? StatsDate { get; set; }

        public int? ZeroPercentDiary { get; set; }
        public string Affinity { get; set; }
        public DateTime? DateCreated { get; set; }
        public string BranchCode { get; set; }
        public string Company { get; set; }
        public string AtlCompanyCode { get; set; }
        public string RegistrationNumber { get; set; }

        public Client Client { set; get; }
    }
}
