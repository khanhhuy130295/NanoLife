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
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService):base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

    }
}
