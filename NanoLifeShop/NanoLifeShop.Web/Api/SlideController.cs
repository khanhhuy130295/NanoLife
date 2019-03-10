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
    [RoutePrefix("api/slide")]
    public class SlideController : ApiControllerBase
    {
        private ISlideService _slideService;
        public SlideController(IErrorService errorService, ISlideService slideService):base(errorService)
        {
            this._slideService = slideService;
        }


        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _slideService.GetAll(keyword);

                TotalRow = listdb.Count();
                var query = listdb.OrderBy(x => x.DisplayOder).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(query);

                var paginationSet = new PaginationSet<SlideViewModel>()
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

                var ItemDetail = _slideService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<Slide, SlideViewModel>(ItemDetail);
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
        public HttpResponseMessage Create(HttpRequestMessage request, SlideViewModel slideVM)
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
                    Slide slideDB = new Slide();
                    slideDB.UpdateSlide(slideVM);

                    var NewItem = _slideService.Add(slideDB);
                    _slideService.Save();

                    var respondeData = Mapper.Map<Slide, SlideViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, SlideViewModel slideVM)
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
                    var slideDB = _slideService.GetSingleByID(slideVM.ID);
                    slideDB.UpdateSlide(slideVM);
                    _slideService.Update(slideDB);
                    _slideService.Save();

                    var responseData = Mapper.Map<Slide, SlideViewModel>(slideDB);

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
                    var oldItem = _slideService.Delete(ID);
                    _slideService.Save();
                    var responseData = Mapper.Map<Slide, SlideViewModel>(oldItem);
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
                        _slideService.Delete(item);
                    }

                    _slideService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }

    }
}
