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
    public class RoleController : ApiController
    {
        [Route("api/roles")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = RoleService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/roles/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = RoleService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/roles/add")]
        [HttpPost]
        public HttpResponseMessage Add(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                var data = RoleService.Add(role);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

        }

        [Route("api/roles/delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            var data = RoleService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
    }
}
