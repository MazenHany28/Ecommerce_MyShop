using BLL.DTOs.Product;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using UI.Helpers;
using UI.ViewModels.Products;

namespace UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService ProductService;

        public ProductsController(IProductService _ProductService)
        {
            ProductService = _ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ProductListViewModel();
            var filters = new ProductFiltersDto();
            var (products, totalProducts,MaxPrice,MinPrice) = await ProductService.GetFilteredAsync(filters);
            
            model.Products=products;
            model.TotalProducts = totalProducts;
            model.MaxPrice = MaxPrice;
            model.MinPrice=MinPrice;
            model.MaxProduct = MaxPrice;

            model.MinProduct = MinPrice;

            return  View(model);
        }

        [HttpPost]
 
        public async Task<IActionResult> Index(ProductListViewModel filtersModel)
        {
            var filters = filtersModel.toFilters();

            var (products, totalProducts, MaxPrice, MinPrice) = await ProductService.GetFilteredAsync(filters);

            filtersModel.Products = products;
            filtersModel.TotalProducts = totalProducts;
            filtersModel.MaxPrice = MaxPrice;
            filtersModel.MaxProduct = MaxPrice;
            filtersModel.MinPrice = MinPrice;
            filtersModel.MinProduct = MinPrice;

            return View(filtersModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details() { 
        

            return View();
        }

    }
}
