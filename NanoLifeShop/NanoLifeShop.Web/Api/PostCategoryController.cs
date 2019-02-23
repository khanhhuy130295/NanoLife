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
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
             {
                 HttpResponseMessage response = null;
                 int TotalRow = 0;

                 var listCatedb = _postCategoryService.GetAll(keyword);

                 TotalRow = listCatedb.Count();
                 var query = listCatedb.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                 var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(query);

                 var paginationSet = new PaginationSet<PostCategoryViewModel>()
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

                var ItemDetail = _postCategoryService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(ItemDetail);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, "Không có dữ liệu !");
                }
                return response;
            });
        }

        [Route("getparent")]
        [HttpGet]
        public HttpResponseMessage GetParent(HttpRequestMessage request)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;

                var listCatedb = _postCategoryService.GetParent();


                var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(listCatedb);

                response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postCateVM)
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
                     PostCategory postCateDb = new PostCategory();
                     postCateDb.UpdatePostCategory(postCateVM);
                     postCateDb.CreateDate = DateTime.Now;

                     var NewItem = _postCategoryService.Add(postCateDb);
                     _postCategoryService.Save();

                     var respondeData = Mapper.Map<PostCategory, PostCategoryViewModel>(NewItem);

                     response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                 }

                 return response;
             });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryViewModel postCateVM)
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
                    var CateDB = _postCategoryService.GetSingleByID(postCateVM.ID);
                    CateDB.UpdatePostCategory(postCateVM);
                    CateDB.UpdateDate = DateTime.Now;
                    _postCategoryService.Update(CateDB);
                    _postCategoryService.Save();

                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(CateDB);

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
                    var oldItem = _postCategoryService.Delete(ID);
                    _postCategoryService.Save();
                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(oldItem);
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
                         _postCategoryService.Delete(item);
                     }

                     _postCategoryService.Save();
                     response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                 }

                 return response;
             });
        }
    }
}