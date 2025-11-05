using BLL.Exceptions;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UI.Helpers;
using UI.ViewModels.Products;

namespace UI.Controllers
{
    [Authorize(Roles ="Buyer")]
    public class BuyerController : Controller
    {

        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IImageService imageService;
        private string BuyerId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public BuyerController(IProductService _productservice,
                                ICategoryService _categoryService,
                                IOrderService _orderService,
                                IImageService _imageservice

                                )
        {
            productService = _productservice;
            categoryService = _categoryService;
            orderService = _orderService;
            imageService = _imageservice;

        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Buyer/ProductIndex
        public async Task<IActionResult> ProductIndex()
        {
            var products = await productService.GetAllByUserIdAsync(BuyerId);
            return View("~/Views/Admin/ProductIndex.cshtml",products);
        }


        // GET: Buyer/ProductDetails/5
        public async Task<IActionResult> ProductDetails(int Id)
        {
            var product = await productService.GetByIdWithDetailsAsync(Id);
            if (product.AddedByUserId != BuyerId)
                throw new NotFoundException("No Product was found with this Id");
            return View("~/Views/Admin/ProductDetails.cshtml", product);
        }

        // GET: Buyer/CreateProduct
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View("~/Views/Admin/CreateProduct.cshtml");
        }

        // POST: Buyer/CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductAddUpdateViewModel productmodel)
        {
            if (ModelState.IsValid)
            {
                productmodel.ImageUrl = await imageService.UploadAsync(productmodel.ImageFile, "images") ?? "images/Icon.png";
                productmodel.AddedByUserId = BuyerId ?? "";

                var productdto = productmodel.ToAddProductDto();
                await productService.AddAsync(productdto);

                return RedirectToAction(nameof(ProductIndex));
            }
            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View("~/Views/Admin/CreateProduct.cshtml", productmodel);
        }

        public async Task<IActionResult> EditProduct(int Id)
        {

            var productdto = await productService.GetByIdWithDetailsAsync(Id);
            if (productdto.AddedByUserId != BuyerId)
                throw new NotFoundException("No Product was found with this Id");
            var model = productdto.ToProductAddUpdateViewModel();

            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", productdto.CategoryId);

            return View("~/Views/Admin/EditProduct.cshtml", model);
        }

        // POST: Buyer/EditProduct/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductAddUpdateViewModel productmodel)
        {
            if (ModelState.IsValid)
            {
                if (productmodel.ImageFile != null)
                {
                    imageService.Delete(productmodel.ImageUrl);
                    productmodel.ImageUrl = await imageService.UploadAsync(productmodel.ImageFile, "images");
                }

                var productdto = productmodel.ToUpdateProductDto();
                await productService.UpdateAsync(productdto);
                return RedirectToAction(nameof(ProductIndex));
            }

            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", productmodel.CategoryId);
            return View("~/Views/Admin/EditProduct.cshtml", productmodel);
        }


        // GET: Buyer/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = await productService.GetByIdWithDetailsAsync(Id);
            if (product.AddedByUserId != BuyerId)
                throw new NotFoundException("No Product was found with this Id");
            return View("~/Views/Admin/DeleteProduct.cshtml", product);
        }

        // POST: Buyer/DeleteProduct/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id, string ImageUrl)
        {
            imageService.Delete(ImageUrl);
            await productService.DeleteByIdAsync(Id);
            return RedirectToAction(nameof(ProductIndex));
        }



    }
}
