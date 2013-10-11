using System;
using System.Web;

namespace OcrApi.Models
{
    public class ParkingDetails
    {
        public int Id { get; set; }
        public HttpPostedFileBase LocationFile { get; set; }
        public User User { get; set; }
        public DateTime Duration { get; set; }
    }
}