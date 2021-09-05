using System;
using System.Collections.Generic;
using System.Text;

namespace Renewal.Application.Models.ProcessingData
{
    public class VerifyPaymentInforRequestModel
    {
        public string PolicyReference { get; set; }
        public string PolicyType { get; set; }
        public string AffinityCode { get; set; }
    }
}
