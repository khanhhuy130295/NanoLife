using AutoMapper;
using NanoLifeShop.Common;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Infastructure.Core;
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
        public ActionResult Index(int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var model = _postService.GetPostShowHome(page, pageSize, out totalRow, new string[] { "PostCategory" });
            var modelVM = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);

            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<PostViewModel>()
            {
                Items = modelVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);


        }

        public ActionResult PostGroupByCate(int IdCate,int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var model = _postService.GetPostByIDCate(IdCate, page, pageSize, out totalRow, new string[] { "PostCategory" });
            var modelVM = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var CateDB = _postCategoryService.GetSingleByID(IdCate);

            ViewBag.CateroryItem = Mapper.Map<PostCategory, PostCategoryViewModel>(CateDB);

            var paginationSet = new PaginationSet<PostViewModel>()
            {
                Items = modelVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }


        public ActionResult Detail(int idPost)
        {
            var modelDb = _postService.GetSingleByID(idPost, new string[] { "PostCategory" });

            var modelVM = Mapper.Map<Post, PostViewModel>(modelDb);
            return View("DetailPost", modelVM);

        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult PostCategory()
        {
            var listDB = _postCategoryService.GetAll(new string[] { "Posts" });
            var listVM = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(listDB);
            return PartialView("PostCategory", listVM.ToList());
        }


        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult RencentPost()
        {
            var listDB = _postService.GetMulti(x => x.Status == true, new string[] { "PostCategory" });
            listDB = listDB.OrderByDescending(x => x.CreateDate).Take(5);
            var listVM = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(listDB);
            return PartialView("RencentPost", listVM.ToList());
        }
    }
}