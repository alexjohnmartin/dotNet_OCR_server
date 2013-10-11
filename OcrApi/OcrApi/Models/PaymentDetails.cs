namespace OcrApi.Models
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Type { get; set; }
        public int Cvv { get; set; }
    }
}