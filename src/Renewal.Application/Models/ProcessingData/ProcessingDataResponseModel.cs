using System;

namespace Renewal.Application.Models.ProcessingData
{
    public class ProcessingDataResponseModel 
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string PolicyType { get; set; }
    }
}
