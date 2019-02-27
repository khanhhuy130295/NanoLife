using System.Web.Mvc;

namespace NanoLifeShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            return PartialView("Menu");
        }


        public PartialViewResult OrderBox()
        {
            return PartialView("OrderBox");
        }


        public PartialViewResult About()
        {
            return PartialView("About");
        }


        public PartialViewResult Benefit()
        {
            return PartialView("Benefit");
        }



        public PartialViewResult Guide()
        {
            return PartialView("Guide");
        }


        public PartialViewResult FeedBack()
        {
            return PartialView("FeedBack");
        }


        public PartialViewResult Contact()
        {
            return PartialView("Contact");
        }
    }
}