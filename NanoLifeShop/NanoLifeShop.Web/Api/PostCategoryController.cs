using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Infastructure.Core;

namespace NanoLifeShop.Web.Api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateResponeBase(request, () =>
             {
                 HttpResponseMessage response = null;

                 response = request.CreateResponse(HttpStatusCode.OK, "Check OK");

                 return response;

             });
        }
    }

}
