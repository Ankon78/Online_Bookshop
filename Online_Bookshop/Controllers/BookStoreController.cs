using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Online_Bookshop.Controllers
{
    public class BookStoreController: ApiController
    {
        [Route ("api/bookstores")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BookStoreService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bookstores/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = BookStoreService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bookstores/add")]
        [HttpGet]

        public HttpResponseMessage add(BookStoreDTO book)
        {
            if (ModelState.IsValid)
            {
                var data = BookStoreService.Add(book);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/bookstores/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BookStoreService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

    }
}