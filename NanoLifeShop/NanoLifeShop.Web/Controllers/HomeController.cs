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
        private IProductService _productService;
        public HomeController(IMenuService menuService,ISupportOnlineService supportService,IProductService productService)
        {
            this._menuService = menuService;
            this._supportService = supportService;
            this._productService = productService;
                
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
            var productDB = _productService.GetSingleByCondition(x => x.Status == true && x.Tags == "Nano");

            var modelProduct = Mapper.Map<Product, ProductViewModel>(productDB);

            return PartialView("OrderBox", modelProduct);
        }


        public PartialViewResult About()
        {
            var productDB = _productService.GetSingleByCondition(x => x.Status == true && x.Tags == "Nano");
            var modelProduct = Mapper.Map<Product, ProductViewModel>(productDB);
            return PartialView("About", modelProduct);
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