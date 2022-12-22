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

namespace FoodDeliveryProject.Controllers
{
    [EnableCors("*","*","*")]
    //[Logged]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/Admin/View/Employees")]
        public HttpResponseMessage GetAllEmployees()
        {
            try
            {
                var data = AdminService.GetEmployees();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Admin/Add")]
        public HttpResponseMessage AddAdmin(AdminDTO data)
        {
            try 
            {
                var user = AdminService.AddAdmin(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Admin/Delete/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                var data = AdminService.DeleteAdmin(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Admin/Update")]
        public HttpResponseMessage UpdateAdmin(AdminDTO data)
        {
            try
            {
                var user = AdminService.AdminUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Admin/ViewAll")]
        public HttpResponseMessage GetAdmins()
        {
            try
            { 
                var data = AdminService.GetAdmins();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Admin/View/{id}")]
        public HttpResponseMessage GetAdmin(int id)
        {
            try
            {
                var data = AdminService.GetAdmin(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
