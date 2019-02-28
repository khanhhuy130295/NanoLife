using AutoMapper;
using NanoLifeShop.Service;
using NanoLifeShop.Web.Infastructure.Core;
using NanoLifeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Web.Infastructure.Extension;
using System.Web.Script.Serialization;

namespace NanoLifeShop.Web.Api
{
    [RoutePrefix("api/menu")]
    [Authorize]
    public class MenuController : ApiControllerBase
    {
        private IMenuService _menuService;
        
        public MenuController(IErrorService errorService, IMenuService menuService):base(errorService)
        {
            this._menuService = menuService;
        }

        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _menuService.GetAll(keyword);

                TotalRow = listdb.Count();
                var query = listdb.OrderBy(x => x.DisplayOder).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(query);

                var paginationSet = new PaginationSet<MenuViewModel>()
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

                var ItemDetail = _menuService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<Menu, MenuViewModel>(ItemDetail);
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
        public HttpResponseMessage Create(HttpRequestMessage request, MenuViewModel menuVM)
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
                    Menu menuDB = new Menu();
                    menuDB.UpdateMenu(menuVM);

                    var NewItem = _menuService.Add(menuDB);
                    _menuService.Save();

                    var respondeData = Mapper.Map<Menu, MenuViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MenuViewModel menuVM)
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
                    var MenuDB = _menuService.GetSingleByID(menuVM.ID);
                    MenuDB.UpdateMenu(menuVM);
                    _menuService.Update(MenuDB);
                    _menuService.Save();

                    var responseData = Mapper.Map<Menu, MenuViewModel>(MenuDB);

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
                    var oldItem = _menuService.Delete(ID);
                    _menuService.Save();
                    var responseData = Mapper.Map<Menu, MenuViewModel>(oldItem);
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
                        _menuService.Delete(item);
                    }

                    _menuService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }

    }
}
