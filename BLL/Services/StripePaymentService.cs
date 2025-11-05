using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StripePaymentService:IPaymentService
    {
        public string PaymentMethodName => "Stripe";
        private readonly IProductService _productService;

        public StripePaymentService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<string> CreatePaymentSessionAsync(List<CartItem> cart , string successUrl , string cancelUrl)
        {
         
            var products = await _productService.GetAllAsync();
            var lineitems = cart.Select(item => new SessionLineItemOptions
            {
                
                PriceData = new SessionLineItemPriceDataOptions
                {  
                    UnitAmount = (long)(item.Price * 100),
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = products.Where(p=>p.Id==item.ProductId).Select(p=>p.Name).First()
                    },
                },
                Quantity = Math.Min(item.Quantity,products.Where(p => p.Id == item.ProductId).Select(p => p.Stock).First()),
            }).ToList();



            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                SuccessUrl = successUrl + "?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = cancelUrl,
                LineItems = lineitems,
                Mode = "payment",
            };
            var service = new SessionService();
            Session session = await  service.CreateAsync(options);
            return session.Url;
        }
    }

}
