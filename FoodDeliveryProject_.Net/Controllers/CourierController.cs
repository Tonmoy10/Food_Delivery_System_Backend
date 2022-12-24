using BLL.DTO;
using BLL.Services;
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
    public class CourierController : ApiController
    {
        [HttpGet]
        [Route("api/Courier/Delete/{id}")]
        public HttpResponseMessage DeleteCourier(int id)
        {
            try
            {
                var data = CourierService.DeleteCourier(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Courier/Update")]
        public HttpResponseMessage UpdateCourier(CourierDTO data)
        {
            try
            {
                var user = CourierService.CourierUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/View/Courier/{id}")]
        public HttpResponseMessage GetCourier(int id)
        {
            try
            {
                var data = CourierService.GetCourier(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
