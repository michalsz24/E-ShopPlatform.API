using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Models
{
    public class CreateFirstPaymentModel
    {
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }

    }
}