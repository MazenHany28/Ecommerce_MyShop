using BLL.DTOs.Orders;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetAllAsync();
        Task<GetOrderDetailsDto?> GetByIdAsync(int Id);
        Task<IEnumerable<GetOrderDto>> GetAllByCustomerAsync(string CustomerID);
        Task AddAsync(List<CartItem> cart, string CustomerId, string paymentprovider, string paymentId);
        Task<GetOrderDetailsDto?> GetByPaymentIdAsync(string Id);
    }
}
