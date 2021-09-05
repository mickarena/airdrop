using System;

namespace Renewal.Application.Models.ProcessingData
{
    public class UpdateStatusRequestModel
    {
        public string PolicyReference { get; set; }
        public string RenewalProcessStatus { get; set; }
        public DateTime RenewalProcessStatusDate { get; set; }
    }
}
