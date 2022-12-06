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
    public class ReportController : ApiController
    {
        // GET:Report
        [Route("api/reports")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = ReportService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/reports/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = ReportService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/reports/add")]
        [HttpGet]

        public HttpResponseMessage add(ReportDTO report)
        {
            if (ModelState.IsValid)
            {
                var data = ReportService.Add(report);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/reports/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = ReportService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }


    }
}