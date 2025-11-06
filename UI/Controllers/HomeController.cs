using BLL.Exceptions;
using BLL.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
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
            var productsCount = await productService.GetCountAsync();
  

           var featuredproductsnum =Math.Min(8, productsCount);
            
            var featuredproducts = await productService.FilterAsync(p => p.Skip( new Random().Next(p.Count()- featuredproductsnum+1) ).Take(featuredproductsnum));
            return View(featuredproducts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();


            if (feature?.Error is NotFoundException)
                return RedirectToAction("StatusCode", new { code = 404 });



            ViewBag.ErrorMessage = feature?.Error.Message;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public new IActionResult StatusCode(int code)
        {
            switch (code)
            {
                case 404:
                    return View("NotFound");

                default:
                    return View("Error");
            }
        }


    }
}
