
using NanoLifeShop.Service;
using NanoLifeShop.Web.Infastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NanoLifeShop.Web.Api
{
    public class PaymentMethodController : ApiControllerBase
    {
        private IPayMentMethodService _payMentMethodService;

        public PaymentMethodController(IErrorService errorService, IPayMentMethodService payMentMethodService):base(errorService)
        {

        }
    }
}
