using E_ShopPlatform.API.Models;
using E_ShopPlatform.API.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace E_ShopPlatform.API.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public HttpResponseMessage CreatePayment(Order order)
        {
            try
            {
                var result = _paymentService.CreatePayment(order);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}