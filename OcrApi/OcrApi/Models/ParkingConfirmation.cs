namespace OcrApi.Models
{
    public class ParkingConfirmation
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public decimal QuotedPrice { get; set; }
        public UserProperties UserProperties { get; set; }
    }
}