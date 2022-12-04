using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using DAL.EF;

namespace Online_Bookshop.Controllers
{
    public class LanguageController : ApiController
    {
        // GET: Language
        [Route("api/languages")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = LanguageService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/languages/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = LanguageService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/languages/add")]
        [HttpGet]

        public HttpResponseMessage add(LanguageDTO language)
        {
            if (ModelState.IsValid)
            {
                var data = LanguageService.Add(language);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/languages/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = LanguageService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }  
    }
}