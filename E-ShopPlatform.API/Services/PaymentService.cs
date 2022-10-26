using E_ShopPlatform.API.Factories.PaymentGateway;
using E_ShopPlatform.API.Helpers;
using E_ShopPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Services
{
    public class PaymentService
    {
        private readonly List<User> UserList = new List<User>()
        {
            new User() {Id = 1, FirstName = "Jan", LastName="Nowak", Email = "jan.nowak@gmail.com" },
            new User() {Id = 2, FirstName = "Halina", LastName="Nowak", Email = "halina.nowak@gmail.com" }
        };

        private readonly PaymentGatewayFactory _paymentFactory;

        public PaymentService(PaymentGatewayFactory paymentGatewayFactory) {
            _paymentFactory = paymentGatewayFactory;
        }

        public string CreatePayment(Order order)
        {
            var paymentFactory = _paymentFactory.Get(order.PaymentGateway);

            var user = GetUserById(order.UserId);

            var createPayment = new CreatePaymentModel()
            {
                Amount = order.Amount,
                Description = order.Description,
                CustomerEmail = user.Email,
                CustomerFirstName = user.FirstName,
                CustomerLastName = user.LastName,
                CreatedDate = DateTime.Now
            };

            var paymentResponse = paymentFactory.CreatePayment(createPayment);
            
            if (!paymentResponse.Success)
            {
                throw new Exception(paymentResponse.Message);
            }

            string receipt = ReceiptHelper.Create(createPayment);

            return receipt;
        }

        private User GetUserById(int id)
        {
            var user = UserList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ValidationException(String.Format("User with id {0} not exist", id));
            }
        }
    }
}