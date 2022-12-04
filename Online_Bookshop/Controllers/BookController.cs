using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Bookshop.Controllers
{
    public class BookController : ApiController
    {
        // GET: Book
        [Route("api/books")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BookService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/books/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = BookService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/books/add")]
        [HttpGet]

        public HttpResponseMessage add(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                var data = BookService.Add(book);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/books/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BookService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
    }
}
