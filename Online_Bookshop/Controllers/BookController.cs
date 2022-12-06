﻿using BLL.DTOs;
using BLL.Services;
using DAL.EF;
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

        public HttpResponseMessage Add(BookDTO book)
        {
            var resp = BookService.Add(book);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = book });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        [Route("api/books/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BookService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
    }
}
