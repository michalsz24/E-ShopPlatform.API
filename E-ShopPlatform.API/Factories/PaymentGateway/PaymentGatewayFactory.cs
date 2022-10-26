using E_ShopPlatform.API.Enums;
using E_ShopPlatform.API.Interfaces;
using E_ShopPlatform.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Factories.PaymentGateway
{
    public class PaymentGatewayFactory
    {
        public IPaymentGatewayFactory Get(PaymentTypes paymentType)
        {
            switch (paymentType)
            {
                case PaymentTypes.FirstPaymentType:
                    return new FirstPaymentMethod();
                case PaymentTypes.SecondPaymentType:
                    return new SecondPaymentMethod();
                default:
                    throw new ValidationException("Wrong PaymentGateway");
            }
        }
    }
}