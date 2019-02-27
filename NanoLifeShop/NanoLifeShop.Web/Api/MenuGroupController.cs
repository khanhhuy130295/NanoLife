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
    [RoutePrefix("api/menuGroup")]
    [Authorize]
   public class MenuGroupController : ApiControllerBase
    {
        IMenuGroupService _menuGroupService;
        public MenuGroupController(IErrorService errorService,IMenuGroupService menuGroupService):base(errorService)
        {
            this._menuGroupService = menuGroupService;
        }


        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listCatedb = _menuGroupService.GetAll(keyword);

                TotalRow = listCatedb.Count();
                var query = listCatedb.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<MenuGroup>, IEnumerable<MenuGroupViewModel>>(query);

                var paginationSet = new PaginationSet<MenuGroupViewModel>()
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

                var ItemDetail = _menuGroupService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<MenuGroup, MenuGroupViewModel>(ItemDetail);
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

                var listCatedb = _menuGroupService.GetParent();


                var responseData = Mapper.Map<IEnumerable<MenuGroup>, IEnumerable<MenuGroupViewModel>>(listCatedb);

                response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, MenuGroupViewModel menuGroupVM)
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
                    MenuGroup menuGroupDB = new MenuGroup();
                    menuGroupDB.UpdateMenuGroup(menuGroupVM);

                    var NewItem = _menuGroupService.Add(menuGroupDB);
                    _menuGroupService.Save();

                    var respondeData = Mapper.Map<MenuGroup, MenuGroupViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, MenuGroupViewModel menuGroupVM)
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
                    var CateDB = _menuGroupService.GetSingleByID(menuGroupVM.ID);
                    CateDB.UpdateMenuGroup(menuGroupVM);

                    _menuGroupService.Update(CateDB);
                    _menuGroupService.Save();

                    var responseData = Mapper.Map<MenuGroup, MenuGroupViewModel>(CateDB);

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
                    var oldItem = _menuGroupService.Delete(ID);
                    _menuGroupService.Save();
                    var responseData = Mapper.Map<MenuGroup, MenuGroupViewModel>(oldItem);
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
                        _menuGroupService.Delete(item);
                    }

                    _menuGroupService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }
    }
}
