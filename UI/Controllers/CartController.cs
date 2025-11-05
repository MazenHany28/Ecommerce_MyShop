using BLL.Helpers;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UI.ViewModels;

namespace UI.Controllers
{
    [Authorize()]
    public class CartController : Controller
    {
        private string CartSessionKey => $"Cart_{User.FindFirst(ClaimTypes.NameIdentifier).Value}";
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public CartController( ICartService cartService, IProductService productService)
        {
           _productService= productService;
            _cartService = cartService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _productService.GetByIdAsync(productId);
            if (product == null)
                return Json(new { success = false, message = "Product not found" });

            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            _cartService.AddItem(cart, product, quantity);
            HttpContext.Session.SetObject(CartSessionKey, cart);

            var subtotal = _cartService.CalculateSubtotal(cart);

            return Json(new
            {
                success = true,
                cartCount = cart.Sum(x => x.Quantity),
                subtotal,
                productName = product.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            _cartService.RemoveItem(cart, productId);
            HttpContext.Session.SetObject(CartSessionKey, cart);

            var subtotal = _cartService.CalculateSubtotal(cart);
            return Json(new { success = true, cartCount = cart.Sum(x => x.Quantity), subtotal });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCart(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var updated = await _cartService.UpdateQuantity(cart, productId, quantity);
            if (!updated) return BadRequest(new { success = false, message = "Item not in cart" });

            HttpContext.Session.SetObject(CartSessionKey, cart);

            var line = cart.First(x => x.ProductId == productId);
            var lineTotal = line.Price * line.Quantity;
            var subtotal = _cartService.CalculateSubtotal(cart);

            return Json(new
            {
                success = true,
                cartCount = cart.Sum(x => x.Quantity),
                subtotal,
                lineTotal
            });
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            return Json(new { cartCount = cart.Sum(x => x.Quantity) });
        }

        // Optionally a Cart page that returns the View:
        [HttpGet]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var vm = new CartViewModel
            {
                CartItems = cart,
                Subtotal = _cartService.CalculateSubtotal(cart),
                ShippingCost = 0m, 
                Tax = 0m
            };
            vm.Total = vm.Subtotal + vm.ShippingCost + vm.Tax;
            return View( vm);
        }
    }
}
