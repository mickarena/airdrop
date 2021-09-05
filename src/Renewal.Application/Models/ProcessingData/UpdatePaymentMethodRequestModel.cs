namespace Renewal.Application.Models.ProcessingData
{
    public class UpdatePaymentMethodRequestModel
    {
        public string PolicyReference { get; set; }
        public string PaymentMethod { get; set; }
        public bool? EmailDocuments { get; set; }
        public bool? StatementofFactConfirmed { get; set; }
        public bool? CPAAuthorisation { get; set; }
    }
}
