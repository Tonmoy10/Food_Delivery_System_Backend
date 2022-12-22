using BLL.DTO;
using BLL.Services;
using FoodDeliveryProject_.Net.AuthFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FoodDeliveryProject_.Net.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            var token = AuthService.Authenticate(login.username, login.password);
            if (token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Usernot found");

        }

        [Logged]
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization;
            var result = AuthService.logout(token.ToString());
            if(result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully logged out");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unsuccessful logout");

        }
    }
}
