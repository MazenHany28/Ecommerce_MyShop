using BLL.DTOs.Orders;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork UoW;
        private readonly IPaymentService paymentService;
        public OrderService(IUnitOfWork _UoW, IPaymentService _paymentService)
        {
            UoW= _UoW;
            paymentService= _paymentService;
        }


        public async Task<IEnumerable<GetOrderDto>> GetAllAsync() { 
        
            var orders = await  UoW.Orders.GetAllAsync(o=>o.Include(o=>o.customer));
            return orders.Select(o=>o.ToGetOrderDto());
        }

        public async Task<GetOrderDetailsDto?> GetByIdAsync(int Id)
        {

            var order = await UoW.Orders.GetByIdWithDetailsAsync(Id);
            if(order!=null)
            return order.ToGetOrderDetailsDto();
            throw new NotFoundException("No Order is found with this Id");
        }

        public async Task<GetOrderDetailsDto?> GetByPaymentIdAsync(string Id)
        {

            var order = await UoW.Orders.GetByPaymentIdAsync(Id);
            if (order != null)
                return order.ToGetOrderDetailsDto();
            throw new NotFoundException("No Order is found with this Payment Id");
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllByCustomerAsync(string CustomerID)
        {

            var orders = await UoW.Orders.GetAllAsync(o => o.Include(o => o.customer)
                                                                                .Where(o=>o.CustomerId==CustomerID));
            return orders.Select(o => o.ToGetOrderDto());
        }

        public async Task AddAsync(List<CartItem> cart,string CustomerId,string paymentprovider,string paymentId) {

            var products = await UoW.Products.GetAllAsync();
            var orderitems = new List<OrderProducts>();
            foreach (var item in cart) {
                orderitems.Add(
                    
                    new OrderProducts() { 
                    ProductId=item.ProductId,
                    Quantity=item.Quantity,
                    UnitPrice=item.Price
                    }
                    
                    );

                var product = products.FirstOrDefault(p=>p.Id==item.ProductId);
                product.Stock -= item.Quantity;

            }


            var order = new Order()
            {
                OrderDate = DateTime.Now,
                CustomerId = CustomerId,
                Total = cart.Sum(item => item.Quantity * item.Price),
                products=orderitems,
                PaymentProvider= paymentprovider,
                PaymentTransactionId= paymentId
            };

            await UoW.Orders.AddAsync(order);
            await UoW.SaveChangesAsync();

        
        }

        public async Task DeleteByIdAsync(int Id) {

            var order = await UoW.Orders.GetByIdAsync(Id);
            if(order==null)
                throw new NotFoundException("No Order is found with this Id");
            UoW.Orders.Delete(order);
            await UoW.SaveChangesAsync();
        }


    }
}
