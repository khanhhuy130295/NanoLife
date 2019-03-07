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
    [RoutePrefix("api/feedback")]
    [Authorize]
    public class FeedBackController : ApiControllerBase
    {
        private IFeedBackService _feedBackService;
        public FeedBackController(IErrorService errorService, IFeedBackService feedBackService):base(errorService)
        {
            this._feedBackService = feedBackService;
        }

        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _feedBackService.GetAll(keyword);

                TotalRow = listdb.Count();
                var query = listdb.OrderBy(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<FeedBack>, IEnumerable<FeedBackViewModel>>(query);

                var paginationSet = new PaginationSet<FeedBackViewModel>()
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

                var ItemDetail = _feedBackService.GetSingleById(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<FeedBack, FeedBackViewModel>(ItemDetail);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, "Không có dữ liệu !");
                }
                return response;
            });
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(HttpRequestMessage request, FeedBackViewModel feedBackVM)
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
                    FeedBack feedBackDB = new FeedBack();
                    feedBackDB.UpdateFeedBack(feedBackVM);

                    var NewItem = _feedBackService.Add(feedBackDB);
                    _feedBackService.Save();

                    var respondeData = Mapper.Map<FeedBack, FeedBackViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, FeedBackViewModel feedBackVM)
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
                    var feedBackDB = _feedBackService.GetSingleById(feedBackVM.ID);
                    feedBackDB.UpdateFeedBack(feedBackVM);
                    _feedBackService.Update(feedBackDB);
                    _feedBackService.Save();

                    var responseData = Mapper.Map<FeedBack, FeedBackViewModel>(feedBackDB);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [HttpDelete]
        [Route("delete")]
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
                    var oldItem = _feedBackService.Delete(ID);
                    _feedBackService.Save();
                    var responseData = Mapper.Map<FeedBack, FeedBackViewModel>(oldItem);
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
                        _feedBackService.Delete(item);
                    }

                    _feedBackService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }
    }
}
