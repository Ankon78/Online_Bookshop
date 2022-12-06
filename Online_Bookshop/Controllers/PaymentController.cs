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
    public class PaymentController : ApiController
    {
        // GET: Payment
        [Route("api/payments")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PaymentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/payments/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = PaymentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/payments/add")]
        [HttpGet]

        public HttpResponseMessage add(PaymentDTO payment)
        {
            if (ModelState.IsValid)
            {
                var data = PaymentService.Add(payment);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/payments/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = PaymentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
    }
}