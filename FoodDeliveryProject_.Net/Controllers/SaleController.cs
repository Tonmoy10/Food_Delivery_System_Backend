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
    public class SaleController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Sale")]
        public HttpResponseMessage AddSale(SaleDTO data)
        {
            try
            {
                var user = SaleService.AddSale(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Sale/Delete/{id}")]
        public HttpResponseMessage DeleteSale(int id)
        {
            try
            {
                var data = SaleService.DeleteSale(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Sale/Update")]
        public HttpResponseMessage UpdateSale(SaleDTO data)
        {
            try
            {
                var user = SaleService.SaleUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Sales")]
        public HttpResponseMessage GetSales()
        {
            try
            {
                var data = SaleService.GetSales();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Sale/{id}")]
        public HttpResponseMessage GetSale(int id)
        {
            try
            {
                var data = SaleService.GetSale(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/revenue")]
        public HttpResponseMessage revenue()
        {
            try
            {
                int data = SaleService.SaleCount();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
