using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Models
{
    public class CreatePaymentModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}