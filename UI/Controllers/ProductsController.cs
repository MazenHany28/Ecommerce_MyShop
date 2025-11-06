using BLL.DTOs.Products;
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
        private readonly ICategoryService CategoryService;

        public ProductsController(IProductService _ProductService, ICategoryService _categoryService)
        {
            ProductService = _ProductService;
            CategoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ProductListViewModel();
            var filters = new ProductFiltersDto();
            var productsCount = await ProductService.GetCountAsync();
            if(productsCount<=0)
                return View(model);
            var (products, totalProducts,MaxPrice,MinPrice) = await ProductService.GetFilteredAsync(filters);
            
            model.Products=products;
            model.TotalProducts = totalProducts;
            model.MaxPrice = MaxPrice;
            model.MinPrice=MinPrice;
            model.MaxProduct = MaxPrice;
            model.MinProduct = MinPrice;
            model.CategoryNames= await CategoryService.GetNamesAsync();
            return  View(model);
        }

        [HttpPost]
 
        public async Task<IActionResult> Index(ProductListViewModel filtersModel)
        {
            var filters = filtersModel.toFilters();

            var (products, totalProducts, MaxPrice, MinPrice) = await ProductService.GetFilteredAsync(filters);

            filtersModel.Products = products;
            filtersModel.TotalProducts = totalProducts;
            filtersModel.MaxProduct = MaxPrice;
            filtersModel.MinProduct = MinPrice;
            //filtersModel.MaxPrice = MaxPrice;
            //filtersModel.MinPrice = MinPrice;
            filtersModel.CategoryNames = await CategoryService.GetNamesAsync();
            return View(filtersModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id) {

            var product = await ProductService.GetByIdWithDetailsAsync(Id);
            var model = product.ToProductDetailsViewModel();
            return View(model);
        }

    }
}
