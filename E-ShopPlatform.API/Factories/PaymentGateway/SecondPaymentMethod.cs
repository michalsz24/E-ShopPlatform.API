using E_ShopPlatform.API.Interfaces;
using E_ShopPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace E_ShopPlatform.API.Factories.PaymentGateway
{
    public class SecondPaymentMethod : IPaymentGatewayFactory
    {
        public CreatePaymentResponse CreatePayment(CreatePaymentModel payment)
        {
            var query = CreateModel(payment);

            return new CreatePaymentResponse()
            {
                Success = true,
                Message = "Order created successfully"
            };
        }

        public CreateSecondPaymentModel CreateModel(CreatePaymentModel payment)
        {
            return new CreateSecondPaymentModel()
            {
                Amount = payment.Amount,
                Email = payment.CustomerEmail,
                CustomerFirstName = payment.CustomerFirstName,
                CustomerLastName = payment.CustomerLastName,
                Description = payment.Description
            };
        }
    }
}