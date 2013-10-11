using System;
using System.Web;
using System.Web.Mvc;
using Ocr_Server.Models;

namespace Ocr_Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult requestParkingQuote(HttpPostedFileBase file, int userId)
        {
            var model = new QuoteModel{LocationId = 1, LocationName = "Impark Vancouver", Price = 3.45m, QuoteId = Guid.NewGuid()};
            var response = new JsonResult();
            response.Data = model; 
            return response;
        }

        [HttpPost]
        public ActionResult confirmParking(Guid quoteId)
        {
            var response = new JsonResult();
            response.Data = new {result = "success"};
            return response;
        }
    }
}
