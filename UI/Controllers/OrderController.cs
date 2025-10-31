using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    //public class OrderController : Controller
    //{
    //    private const string CartSessionKey = "cart";
    //    private readonly IOrderService _orderService;
    //    private readonly ICartService _cartService;

    //    public OrderController(IOrderService orderService, ICartService cartService)
    //    {
    //        _orderService = orderService;
    //        _cartService = cartService;
    //    }

    //    [HttpGet]
    //    public IActionResult Checkout()
    //    {
    //        var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
    //        if (!cart.Any()) return RedirectToAction("Index", "Products");
    //        var vm = new CartViewModel
    //        {
    //            CartItems = cart,
    //            Subtotal = _cartService.CalculateSubtotal(cart)
    //        };
    //        vm.Total = vm.Subtotal + vm.ShippingCost + vm.Tax;
    //        return View(vm); // a Checkout view you create
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult PlaceOrder(/* take payment / shipping info here */)
    //    {
    //        var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
    //        if (!cart.Any())
    //            return RedirectToAction("Cart", "Cart");

    //        // IMPORTANT: Re-validate prices/stock in OrderService
    //        var result = _orderService.CreateOrderFromCart(cart, /* user info */);
    //        if (!result.Success)
    //        {
    //            TempData["Error"] = result.Message;
    //            return RedirectToAction("Checkout");
    //        }

    //        // Clear session cart
    //        HttpContext.Session.Remove(CartSessionKey);

    //        return RedirectToAction("Success");
    //    }

    //    public IActionResult Success()
    //    {
    //        return View();
    //    }
    //}
}
