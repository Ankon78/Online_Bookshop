using BLL.DTOs;
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
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var data = UserService.Add(user);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

        }

        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

        [Route("api/user/update")]
        [HttpPost]
        public HttpResponseMessage Update(User s)
        {
            UserService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}
