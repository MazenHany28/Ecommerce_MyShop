using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentService
    {
        public string PaymentMethodName { get; }
        
        Task<string> CreatePaymentSessionAsync(List<CartItem> cart, string successUrl,
                                                                string cancelUrl);
    }
}
