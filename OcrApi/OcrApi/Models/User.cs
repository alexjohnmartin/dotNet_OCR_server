namespace OcrApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Account { get; set; }
        public string Pin { get; set; }
        public string PinConfirmation { get; set; }
        public PaymentDetails Payment { get; set; }
        public UserProperties UserProperties { get; set; }
    }
}