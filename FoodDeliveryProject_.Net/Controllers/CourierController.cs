using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodDeliveryProject_.Net.Controllers
{
    public class CourierController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Courier")]
        public HttpResponseMessage AddCourier(CourierDTO data)
        {
            try
            {
                var user = CourierService.AddCourier(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
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
        [Route("api/View/Couriers")]
        public HttpResponseMessage GetCouriers()
        {
            try
            {
                var data = CourierService.GetCouriers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
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
