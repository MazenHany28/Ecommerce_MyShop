using BLL.DTOs.Products;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task AddItem(List<CartItem> cart, GetProductDto product, int qty = 1);
        void RemoveItem(List<CartItem> cart, int productId);
        Task<bool> UpdateQuantity(List<CartItem> cart, int productId, int quantity);
        decimal CalculateSubtotal(List<CartItem> cart);
    }

}
