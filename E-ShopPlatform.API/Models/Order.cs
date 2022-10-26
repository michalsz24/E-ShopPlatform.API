using System;
using E_ShopPlatform.API.Enums;

namespace E_ShopPlatform.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public PaymentTypes PaymentGateway { get; set; }
        public string Description { get; set; }
    }
}