using E_ShopPlatform.API.Interfaces;
using E_ShopPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Factories.PaymentGateway
{
    public class FirstPaymentMethod : IPaymentGatewayFactory
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

        public CreateFirstPaymentModel CreateModel(CreatePaymentModel payment)
        {
            return new CreateFirstPaymentModel() {
                Amount = payment.Amount,
                Email = payment.CustomerEmail,
                CustomerName = string.Format("{0} {1}", payment.CustomerFirstName, payment.CustomerLastName),
                Description = payment.Description
            };
        }
    }
}