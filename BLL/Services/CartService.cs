using BLL.DTOs.Products;
using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private const int MaxPerItem = 100;

        public void AddItem(List<CartItem> cart, GetProductDto product, int qty = 1)
        {
            var existing = cart.FirstOrDefault(x => x.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity = Math.Min(MaxPerItem, existing.Quantity + qty);
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = Math.Min(MaxPerItem, qty),
                    ImageUrl = product.ImageUrl,
                    description = product.Description,
                });
            }
        }

        public void RemoveItem(List<CartItem> cart, int productId)
        {
            cart.RemoveAll(x => x.ProductId == productId);
        }

        public bool UpdateQuantity(List<CartItem> cart, int productId, int quantity)
        {
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item == null) return false;
            item.Quantity = Math.Min(MaxPerItem, Math.Max(1, quantity));
            return true;
        }

        public decimal CalculateSubtotal(List<CartItem> cart)
            => cart?.Sum(x => x.Price * x.Quantity) ?? 0m;
    }

}
