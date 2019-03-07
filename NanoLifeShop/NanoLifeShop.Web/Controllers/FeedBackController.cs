using NanoLifeShop.Common;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NanoLifeShop.Web.Controllers
{
    public class FeedBackController : Controller
    {
        private IFeedBackService _feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            this._feedBackService = feedBackService;
        }

        // GET: FeedBack
        public ActionResult Index()
        {
            return View();
        }
     


        [HttpPost]
        public JsonResult SendFeedBack(string strModel)
        {
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            FeedBack feedBack = serialize.Deserialize<FeedBack>(strModel);
            bool result = false;
            string message = string.Empty;
            var ItemNew = _feedBackService.Add(feedBack);
            _feedBackService.Save();

            if (ItemNew != null)
            {
                result = true;
                message = "Cảm ơn quý khách đã liên hệ !";            
                SendMailSMTP(feedBack);
            }
            else
            {
                result = false;
                message = "Vui lòng thử lại sau !";
            }

            return Json(new
            {
                status = result,
                Message = message
            });
        }


        private void SendMailSMTP(FeedBack feedBack)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/templateEmail/EmailContact.html"));
            content = content.Replace("{{Name}}", feedBack.Name);
            content = content.Replace("{{Messages}}", feedBack.Messages);
            content = content.Replace("{{Email}}", feedBack.Email);
            content = content.Replace("{{Year}}", DateTime.Now.Year.ToString());
            new MailHelper().SendMail(feedBack.Email, "Yêu cầu của khách hàng", content);

        }
    }
}