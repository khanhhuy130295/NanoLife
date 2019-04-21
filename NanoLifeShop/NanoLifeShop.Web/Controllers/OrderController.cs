using NanoLifeShop.Common;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NanoLifeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private IProductService _productService;
        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IProductService productService)
        {
            this._orderDetailService = orderDetailService;
            this._orderService = orderService;
            this._productService = productService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetDataOder(string Name, string Email, string Phone, string Quantity)
        {
            bool result = false;

            Order OrderDB = new Order()
            {
                CreateDate = DateTime.Today,
                CreateBy = "Client",
                CustomerAddress = "",
                CustomerEmail = Email,
                CustomerMessages = "",
                CustomerName = Name,
                CustomerPhone = Phone,
                Status = true,
                PaymentMethod = "Đặt hàng Online",
                PaymentStatus = "Chưa xác nhận"
            };

            var ItemDB = _orderService.Add(OrderDB);
            _orderService.Save();
            var ProductDB = _productService.GetSingleByCondition(x => x.Status == true && x.Tags == "Nano");

            int quantityConvertInt = int.Parse(Quantity);
            if (ProductDB != null)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    ID_Order = ItemDB.ID,
                    ID_Product = ProductDB.ID,
                    Quantity = quantityConvertInt,
                    Price = ProductDB.Price,
                    TotalPrice = quantityConvertInt * ProductDB.Price,
                };

                var ItemNew = _orderDetailService.Add(orderDetail);
                _orderDetailService.Save();
                result = true;

                SendMailSMTP(Name, Email, Phone, Quantity, ItemNew.TotalPrice);
            }
            else
            {
                _orderService.Delete(ItemDB.ID);
                _orderService.Save();
                result = false;
            }

            return Json(new
            {
                status = result
            });
        }


        public void SendMailSMTP(string Name, string Email, string Phone, string quantity, decimal total)
        { 
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/templateEmail/EmailOrder.html"));
            content = content.Replace("{{Name}}", Name);
            content = content.Replace("{{Phone}}", Phone);
            content = content.Replace("{{Quantity}}", quantity);
            content = content.Replace("{{DateTime}}", DateTime.Now.ToString("d"));
            content = content.Replace("{{Total}}", total.ToString("N0"));

            var toEmail = ConfigurationManager.AppSettings["ToEmailAdress"].ToString();
            new MailHelper().SendMail(toEmail, "Đơn đặt hàng", content);
        }

    }
}