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
        private ISlideService _slideService;
        public HomeController(IMenuService menuService, ISlideService slideService,
            ISupportOnlineService supportService, IProductService productService)
        {
            this._menuService = menuService;
            this._supportService = supportService;
            this._productService = productService;
            this._slideService = slideService;

        }

        public ActionResult Index()
        {
            return View();
        }


        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var listMenuDB = _menuService.ShowHomeData();

            var listData = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(listMenuDB);

            return PartialView("Menu", listData);
        }

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult MenuPost()
        {
            var listMenuDB = _menuService.ShowHomeData();

            var listData = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(listMenuDB);

            return PartialView("MenuForPost", listData);
        }


        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult OrderBox()
        {
            var productDB = _productService.GetSingleByCondition(x => x.Status == true && x.Tags == "Nano");

            var modelProduct = Mapper.Map<Product, ProductViewModel>(productDB);

            return PartialView("OrderBox", modelProduct);
        }

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult About()
        {
            var productDB = _productService.GetSingleByCondition(x => x.Status == true && x.Tags == "Nano");
            var modelProduct = Mapper.Map<Product, ProductViewModel>(productDB);
            return PartialView("About", modelProduct);
        }

        [ChildActionOnly]
        public ActionResult Benefit()
        {
            return PartialView("Benefit");
        }

        [ChildActionOnly]
        public ActionResult Guide()
        {
            return PartialView("Guide");
        }

        [ChildActionOnly]
        public ActionResult FeedBack()
        {
            var modelDB = _slideService.ShowHomeData();
            var modelVM = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(modelDB);
            return PartialView("FeedBack",modelVM);
        }

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult Contact()
        {
            var supportDB = _supportService.GetSingleById(1);
            var model = Mapper.Map<SupportOnline, SupportOnlineViewModel>(supportDB);
            return PartialView("Contact", model);
        }

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var supportDB = _supportService.GetSingleById(1);
            var model = Mapper.Map<SupportOnline, SupportOnlineViewModel>(supportDB);
            return PartialView("Footer", model);
        }

    }
}