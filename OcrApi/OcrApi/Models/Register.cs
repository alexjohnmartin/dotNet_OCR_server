using System.Web;

namespace OcrApi.Models
{
    public class Register
    {
        public int Id { get; set; }
        public HttpPostedFileBase CardFile { get; set; }
        public User User { get; set; }
    }
}