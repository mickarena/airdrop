using System;

namespace Renewal.Application.Models.ProcessingData
{
    public class UpdatePaymentTransactionRequestModel
    {
        public string PolicyReference { get; set; }
        public string RenewalProcessStatus { get; set; }
        public DateTime RenewalProcessStatusDate { get; set; }
        public string PaymentTransactionId { get; set; }
        public long? AmountPaid { get; set; }
        public DateTime? PaymentDateCreated { get; set; }
    }
}
