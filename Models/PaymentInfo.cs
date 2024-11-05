namespace WebPhone.Models
{
    public class PaymentInfo
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
