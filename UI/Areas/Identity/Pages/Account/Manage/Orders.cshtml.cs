using BLL.DTOs.Orders;
using BLL.Interfaces;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace UI.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderService orderService;

        public IEnumerable<GetOrderDto> Orders { get; set; } = [];

        public OrdersModel(IOrderService _orderService)
        {
            orderService = _orderService; 
        }

        public async Task <IActionResult> OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await orderService.GetAllByCustomerAsync(userId);
            Orders = orders;
            return Page();
        }
    }
}
