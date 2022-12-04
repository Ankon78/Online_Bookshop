using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Online_Bookshop.Controllers
{
    public class BuyController : ApiController
    {
        // GET: Buy
        [Route("api/buys")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BuyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/buys/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = BuyService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/buys/add")]
        [HttpGet]

        public HttpResponseMessage add(BuyDTO buy)
        {
            if (ModelState.IsValid)
            {
                var data = BuyService.Add(buy);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/buys/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BuyService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }  

    }
}