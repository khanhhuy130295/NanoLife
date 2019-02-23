using NanoLifeShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Web.Infastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateResponeBase(HttpRequestMessage request, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage response = null;

            try
            {
                response = func.Invoke();
            }
            catch(DbEntityValidationException DbEx)
            {
                foreach (var eve in DbEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }

                response = request.CreateResponse(HttpStatusCode.BadRequest, DbEx.InnerException.Message);
                LogErrorDB(DbEx.InnerException);
            }
            catch(DbUpdateException DbUpEx)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, DbUpEx.InnerException.Message);
                LogErrorDB(DbUpEx.InnerException);
            }
            catch(Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                LogErrorDB(ex);
            }

            return response;

        }

        private void LogErrorDB(Exception ex)
        {
            try
            {
                Error error = new Error();

                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                error.CreateDate = DateTime.Now;

                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {

            }
               
        }


    }
}
    