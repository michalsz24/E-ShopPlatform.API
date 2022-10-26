using E_ShopPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Interfaces
{
    public interface IPaymentGatewayFactory
    {
        CreatePaymentResponse CreatePayment(CreatePaymentModel payment);
    }
}