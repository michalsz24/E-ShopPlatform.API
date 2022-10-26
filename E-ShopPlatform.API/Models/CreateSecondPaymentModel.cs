using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Models
{
    public class CreateSecondPaymentModel
    {
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Description { get; set; }
    }
}