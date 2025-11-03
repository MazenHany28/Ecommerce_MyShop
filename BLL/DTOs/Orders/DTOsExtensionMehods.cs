using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Orders
{
    public static class DTOsExtensionMehods
    {
        public static GetOrderDetailsDto ToGetOrderDetailsDto(this Order order) {

            List<OrderItemDto> _OrderItems =new List<OrderItemDto>();
            foreach (var orderitem in order.products) {

                _OrderItems.Add(
                    new OrderItemDto()
                    {
                        ProductName = orderitem.product.Name,
                        ProductImageURL = orderitem.product.ImageUrl,
                        UnitPrice = orderitem.UnitPrice,
                        Quantity = orderitem.Quantity

                    });
            }
            
            return new GetOrderDetailsDto()
            {
                Id=order.Id,
                OrderDate=order.OrderDate,
                Total=order.Total,
                PaymentProvider=order.PaymentProvider,
                PaymentTransactionId=order.PaymentTransactionId,
                CustomerId=order.CustomerId,
                CustomerName=order.customer.UserName,
                OrderItems= _OrderItems};
        }



        public static GetOrderDto ToGetOrderDto(this Order order)
        {

            return new GetOrderDto()
            {
                        Id =order.Id,
                        OrderDate =order.OrderDate,
                        Total =order.Total,
                        PaymentProvider=order.PaymentProvider,
                        PaymentTransactionId =order.PaymentTransactionId,
                        CustomerId =order.CustomerId,
                        CustomerName =order.customer.UserName
            };


        }
    }
}
