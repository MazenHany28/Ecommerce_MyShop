using BLL.Helpers;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.ViewModels;
using Stripe.Checkout;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    public class OrderController : Controller
    {
        private string CartSessionKey => $"Cart_{User.FindFirst(ClaimTypes.NameIdentifier).Value}";
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;

        public OrderController(IOrderService orderService,
            ICartService cartService,
            IPaymentService paymentService)
        {
            _orderService = orderService;
            _cartService = cartService;
            _paymentService= paymentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            if (!cart.Any()) return RedirectToAction("Index", "Products");
            var request = HttpContext?.Request;
            string BaseUrl = $"{request.Scheme}://{request.Host}";
            string SuccessUrl = $"{BaseUrl}/Order/Success";
            string CancelUrl = $"{BaseUrl}/Order/Cancel";
            string paymentsessionUrl = await _paymentService.CreatePaymentSessionAsync(cart, SuccessUrl, CancelUrl);
            return Redirect(paymentsessionUrl);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Success(string session_id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");

            var service = new SessionService();
            var session = await  service.GetAsync(session_id);

            if (session.PaymentStatus == "paid")
            {
                string CustomerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string paymentProvider = _paymentService.PaymentMethodName;
                string paymentId = session.PaymentIntentId;
                await _orderService.AddAsync(cart, CustomerId,paymentProvider,paymentId);
                // Clear session cart
                HttpContext.Session.Remove(CartSessionKey);
                ViewData["AmountPaid"]=(session.AmountTotal/100).ToString();
                return View("Success");
            }
            return View("Failed");
           
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
