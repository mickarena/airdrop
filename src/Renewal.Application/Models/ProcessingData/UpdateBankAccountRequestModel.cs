namespace Renewal.Application.Models.ProcessingData
{
    public class UpdateBankAccountRequestModel
    {
        public string PolicyReference { get; set; }
        public bool? DirectDebitReadConfirmation { get; set; }
        public bool? DirectDebitRepaymentConfirmation { get; set; }
        public string EncryptedAccountHolder { get; set; }
        public string EncryptedBankAccountNumber { get; set; }
        public string EncryptedBankSortCode { get; set; }
        public string BankName { get; set; }
    }
}
