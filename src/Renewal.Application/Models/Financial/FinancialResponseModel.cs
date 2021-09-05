using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Application.Models.Financial
{
    public class FinancialResponseModel
    {
        public string PolicyReference { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public int TotalPremiumPIF { get; set; }
        public byte NumberInstalments { get; set; }
        public int MonthlyPayment { get; set; }
        public int Deposit { get; set; }
        public int FinanceCharge { get; set; }
        public int TotalPremiumDD { get; set; }
        public int APR { get; set; }
        public int InterestRate { get; set; }
        public DateTime RenewalDate { get; set; }
        public string VehicleRegistration { get; set; }
        public string AffinityCode { get; set; }
        public string PolicyType { get; set; }
    }
}
