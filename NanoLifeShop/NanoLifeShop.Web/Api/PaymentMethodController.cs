
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
    [RoutePrefix("api/paymentMethod")]
    [Authorize]
    public class PaymentMethodController : ApiControllerBase
    {
        private IPayMentMethodService _payMentMethodService;

        public PaymentMethodController(IErrorService errorService, IPayMentMethodService payMentMethodService):base(errorService)
        {
            this._payMentMethodService = payMentMethodService;
        }


        [HttpGet]
        [Route("getall")]

        public HttpResponseMessage GetList(HttpRequestMessage request, int idOrder, int page, int pageSize)
        {

            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;
                int TotalRow = 0;

                var listdb = _payMentMethodService.GetAll();

                TotalRow = listdb.Count();

                var responseData = Mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodViewModel>>(listdb);

                var paginationSet = new PaginationSet<PaymentMethodViewModel>()
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
        public HttpResponseMessage GetDetail(HttpRequestMessage request, string id)
        {
            return CreateResponeBase(request, () =>
            {
                HttpResponseMessage response = null;

                var ItemDetail = _payMentMethodService.GetSingleByID(id);
                if (ItemDetail != null)
                {
                    var responseData = Mapper.Map<PaymentMethod, PaymentMethodViewModel>(ItemDetail);
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

                var listMethoddb = _payMentMethodService.GetParent();

                var responseData = Mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodViewModel>>(listMethoddb);

                response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(HttpRequestMessage request,  PaymentMethodViewModel paymentMethodVM)
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
                    PaymentMethod paymentMethod = new PaymentMethod();
                    paymentMethod.UpdatePaymentMethod(paymentMethodVM);

                    var NewItem = _payMentMethodService.Add(paymentMethod);
                    _payMentMethodService.Save();

                    var respondeData = Mapper.Map<PaymentMethod, PaymentMethodViewModel>(NewItem);

                    response = request.CreateResponse(HttpStatusCode.OK, respondeData);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, PaymentMethodViewModel paymentMethodVM)
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
                    var paymentMethodDB = _payMentMethodService.GetSingleByID(paymentMethodVM.ID_PaymentMethod);
                    paymentMethodDB.UpdatePaymentMethod(paymentMethodVM);
                    _payMentMethodService.Update(paymentMethodDB);
                    _payMentMethodService.Save();

                    var responseData = Mapper.Map<PaymentMethod, PaymentMethodViewModel>(paymentMethodDB);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }

                return response;
            });
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string ID)
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
                    var oldItem = _payMentMethodService.Delete(ID);
                    _payMentMethodService.Save();
                    var responseData = Mapper.Map<PaymentMethod, PaymentMethodViewModel>(oldItem);
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
                    var listParseJson = new JavaScriptSerializer().Deserialize<List<string>>(ListItem);

                    foreach (var item in listParseJson)
                    {
                        _payMentMethodService.Delete(item);
                    }

                    _payMentMethodService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listParseJson.Count());
                }

                return response;
            });
        }

    }
}
