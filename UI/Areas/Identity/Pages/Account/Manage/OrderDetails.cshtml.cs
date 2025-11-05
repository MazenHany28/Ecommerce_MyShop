using BLL.DTOs.Orders;
using BLL.Interfaces;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace UI.Areas.Identity.Pages.Account.Manage
{
    public class OrderDetailsModel : PageModel
    {

        private readonly IOrderService orderService;

        public GetOrderDetailsDto Order { get; set; }

        public OrderDetailsModel(IOrderService _orderService)
        {
            orderService = _orderService;
        }


        public async Task<IActionResult> OnGet(int Id)
        {
            var order = await orderService.GetByIdAsync(Id);
            Order = order;
            return Page(); 
        }
    }
}
