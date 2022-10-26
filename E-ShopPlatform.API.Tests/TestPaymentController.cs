using Microsoft.VisualStudio.TestTools.UnitTesting;
using E_ShopPlatform.API.Controllers;
using E_ShopPlatform.API.Models;
using E_ShopPlatform.API.Enums;
using E_ShopPlatform.API.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Moq;
using E_ShopPlatform.API.Services;
using E_ShopPlatform.API.Factories.PaymentGateway;

namespace E_ShopPlatform.API.Tests
{
    [TestClass]
    public class TestPaymentController
    {
        private readonly Order order = new Order() { Id = 1, UserId = 2, Amount = 50, Description = "Test Payment", PaymentGateway = PaymentTypes.FirstPaymentType};

        [TestMethod]
        public void CreatePayment_ShouldReturnReceiptAsBase64()
        {
            var mockPaymentFactory = new PaymentGatewayFactory();
            var mockPaymentService = new PaymentService(mockPaymentFactory);
            var mockPaymentController = new PaymentController(mockPaymentService);

            mockPaymentController.Request = new HttpRequestMessage();
            mockPaymentController.Configuration = new HttpConfiguration();

            var response = mockPaymentController.CreatePayment(order);

            Assert.IsTrue(response.TryGetContentValue<string>(out string receipt));
            Assert.IsTrue(IsBase64String(receipt));
        }

        private bool IsBase64String(string base64)
        {
            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
