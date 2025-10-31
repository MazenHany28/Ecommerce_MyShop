using System.Diagnostics;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        public HomeController(IProductService _productService)
        {
            productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredproductsnum = 8;
            var featuredproducts = await productService.FilterAsync(p => p.Skip( new Random().Next(p.Count()- featuredproductsnum+1) ).Take(featuredproductsnum));
            return View(featuredproducts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
