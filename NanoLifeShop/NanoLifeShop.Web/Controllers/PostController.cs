using AutoMapper;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NanoLifeShop.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;
        private IPostCategoryService _postCategoryService;

        public PostController(IPostService postService, IPostCategoryService postCategoryService)
        {
            this._postService = postService;
            this._postCategoryService = postCategoryService;
        }

        // GET: Post
        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var model = _postService.GetAll(new string[] { "PostCategory"});

            var modelVM = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);

            return View(modelVM.ToPagedList(pageNumber, pageSize));
        }




        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult PostCategory()
        {
            var listDB = _postCategoryService.GetAll(new string[] { "Posts" });
            var listVM = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(listDB);
            return PartialView("PostCategory",listVM.ToList());
        }
    }
}