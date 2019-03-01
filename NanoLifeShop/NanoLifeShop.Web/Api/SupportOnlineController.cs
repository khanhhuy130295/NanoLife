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
    [RoutePrefix("api/supportonline")]
    [Authorize]
    public class SupportOnlineController : ApiControllerBase
    {
        private ISupportOnlineService _supportOnlineService;
        public SupportOnlineController(IErrorService errorService,ISupportOnlineService supportOnlineService):base(errorService)
        {
            this._supportOnlineService = supportOnlineService;
        }

        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _supportOnlineService.GetAll(keyword);

                TotalRow = listdb.Count();
                var query = listdb.OrderBy(x => x.DisplayOder).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<SupportOnline>, IEnumerable<SupportOnlineViewModel>>(query);

                var paginationSet = new PaginationSet<SupportOnlineViewModel>()
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

                var ItemDetail = _supportOnlineService.GetSingleById(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<SupportOnline, SupportOnlineViewModel>(ItemDetail);
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
        public HttpResponseMessage Create(HttpRequestMessage request, SupportOnlineViewModel supportVM)
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
                    SupportOnline supportDB = new SupportOnline();
                    supportDB.UpdateSupportOnline(supportVM);

                    var NewItem = _supportOnlineService.Add(supportDB);
                    _supportOnlineService.Save();

                    var respondeData = Mapper.Map<SupportOnline, SupportOnlineViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, SupportOnlineViewModel supportVM)
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
                    var supportDB = _supportOnlineService.GetSingleById(supportVM.ID);
                    supportDB.UpdateSupportOnline(supportVM);
                    _supportOnlineService.Update(supportDB);
                    _supportOnlineService.Save();

                    var responseData = Mapper.Map<SupportOnline, SupportOnlineViewModel>(supportDB);

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
                    var oldItem = _supportOnlineService.Delete(ID);
                    _supportOnlineService.Save();
                    var responseData = Mapper.Map<SupportOnline, SupportOnlineViewModel>(oldItem);
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
                        _supportOnlineService.Delete(item);
                    }

                    _supportOnlineService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }
    }
}
