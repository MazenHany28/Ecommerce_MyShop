using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Orders
{
    public class GetOrderDetailsDto
    {
        public int Id { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Payment Provider")]
        public string PaymentProvider { get; set; } = string.Empty;
        [Display(Name = "Payment Transaction Id")]
        public string PaymentTransactionId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}
