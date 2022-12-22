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
    public class ItemController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Item")]
        public HttpResponseMessage AddItem(ItemDTO data)
        {
            try
            {
                var user = ItemService.AddItem(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Item/Delete/{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            try
            {
                var data = ItemService.DeleteItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Item/Update")]
        public HttpResponseMessage UpdateItem(ItemDTO data)
        {
            try
            {
                var user = ItemService.ItemUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Items")]
        public HttpResponseMessage GetItems()
        {
            try
            {
                var data = ItemService.GetItems();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Item/{id}")]
        public HttpResponseMessage GetItem(int id)
        {
            try
            {
                var data = ItemService.GetItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
