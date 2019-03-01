using AutoMapper;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NanoLifeShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMenuService _menuService;
        private ISupportOnlineService _supportService;
        public HomeController(IMenuService menuService,ISupportOnlineService supportService)
        {
            this._menuService = menuService;
            this._supportService = supportService;
                
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
          var listMenuDB =  _menuService.ShowHomeData();

            var listData = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(listMenuDB);

            return PartialView("Menu",listData);
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
            var supportDB = _supportService.GetSingleById(1);

            var model = Mapper.Map<SupportOnline, SupportOnlineViewModel>(supportDB);
           
            return PartialView("Contact",model);
        }
    }
}