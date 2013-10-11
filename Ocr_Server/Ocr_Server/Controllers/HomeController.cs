using System.Web;
using System.Web.Mvc;

namespace Ocr_Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult uploadImage(HttpPostedFileBase file, int userId)
        {
            if (file != null && file.ContentLength > 0) 
                return new HttpStatusCodeResult(200);

            return new HttpStatusCodeResult(400);
        }
    }
}
