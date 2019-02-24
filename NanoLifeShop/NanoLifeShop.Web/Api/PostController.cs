using AutoMapper;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Infastructure.Core;
using NanoLifeShop.Web.Infastructure.Extension;
using NanoLifeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NanoLifeShop.Web.Api
{
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        private IPostService _postService;
        public PostController(IErrorService errorService, IPostService postService) : base(errorService)
        {
            this._postService = postService;
        }


        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _postService.GetAll(keyword);

                TotalRow = listdb.Count();
                var query = listdb.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(query);

                var paginationSet = new PaginationSet<PostViewModel>()
                {
                    TotalCount = TotalRow,
                    TotalPages = (int)Math.Ceiling((decimal)TotalRow / pageSize),
                    Items = responseData,
                    Page = page

                };

                response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [HttpGet]
        [Route("getdetail/{id:int}")]
        public HttpResponseMessage GetDetail(HttpRequestMessage request, int id)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;

                var ItemDetail = _postService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<Post, PostViewModel>(ItemDetail);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, "Không có dữ liệu !");
                }
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postVM)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Post postDb = new Post();
                    postDb.UpdatePost(postVM);
                    postDb.CreateDate = DateTime.Now;

                    var NewItem = _postService.Add(postDb);
                    _postService.Save();

                    var respondeData = Mapper.Map<Post, PostViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel postVM)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, ModelState);
                }
                else
                {
                    var PostDB = _postService.GetSingleByID(postVM.ID);
                    PostDB.UpdatePost(postVM);
                    PostDB.UpdateDate = DateTime.Now;
                    _postService.Update(PostDB);
                    _postService.Save();

                    var responseData = Mapper.Map<Post, PostViewModel>(PostDB);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int ID)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldItem = _postService.Delete(ID);
                    _postService.Save();
                    var responseData = Mapper.Map<Post, PostViewModel>(oldItem);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [Route("deleteMulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMultiItem(HttpRequestMessage request, string ListItem)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listParseJson = new JavaScriptSerializer().Deserialize<List<int>>(ListItem);

                    foreach (var item in listParseJson)
                    {
                        _postService.Delete(item);
                    }

                    _postService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }


    }
}
