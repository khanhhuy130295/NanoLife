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
    public class PostController : ApiControllerBase
    {
        IPostService _postService;
        public PostController(IErrorService errorService,IPostService postService):base(errorService)
        {
            this._postService = postService;
        }



    }
}
