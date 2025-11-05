using BLL.DTOs.Categories;
using BLL.Interfaces;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Helpers;
using UI.ViewModels.Products;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IImageService imageService;


        public AdminController(IProductService _productservice,
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

        public IActionResult Index() { 
            return View();
        }

        // GET: Admin/ProductIndex
        public async Task<IActionResult> ProductIndex()
        {
            var products = await productService.GetAllWithDetailsAsync();
            return View(products);
        }

        public async Task<IActionResult> CategoryIndex()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

        // GET: Admin/ProductDetails/5
        public async Task<IActionResult> ProductDetails(int Id)
        {
            var product = await productService.GetByIdWithDetailsAsync(Id);

            return View(product);
        }

        // GET: Admin/CreateProduct
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Admin/CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductAddUpdateViewModel productmodel)
        {
            if (ModelState.IsValid)
            {
                productmodel.ImageUrl = await imageService.UploadAsync(productmodel.ImageFile,"images")??"images/Icon.png";
                productmodel.AddedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)??"";
                //productmodel.AddedByUserId = userManager.GetUserId(User);

                var productdto = productmodel.ToAddProductDto();
                await productService.AddAsync(productdto);
 
                return RedirectToAction(nameof(ProductIndex));
            }
            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View(productmodel);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(AddCategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.AddAsync(categoryDto);

                return RedirectToAction(nameof(CategoryIndex));
            }
            return View(categoryDto);
        }

        // GET: Admin/EditProduct/5
        public async Task<IActionResult> EditProduct(int Id)
        {

            var productdto = await productService.GetByIdWithDetailsAsync(Id);
            var model = productdto.ToProductAddUpdateViewModel();

            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name",productdto.CategoryId);

            return View(model);
        }

        // POST: Admin/EditProduct/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductAddUpdateViewModel productmodel)
        {
            if (ModelState.IsValid)
            {
                if (productmodel.ImageFile != null) {
                    imageService.Delete(productmodel.ImageUrl);
                    productmodel.ImageUrl = await imageService.UploadAsync(productmodel.ImageFile, "images");
                }

                var productdto=productmodel.ToUpdateProductDto();
                await productService.UpdateAsync(productdto);
                return RedirectToAction(nameof(ProductIndex));
            }

            var categories = await categoryService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", productmodel.CategoryId);
            return View(productmodel);
        }

        public async Task<IActionResult> EditCategory(int Id)
        {

            var GetCategorydto = await categoryService.GetByIdAsync(Id);
            var UpdateCategoryDto = new UpdateCategoryDto() { 
            
            Id=GetCategorydto.Id,
            Description=GetCategorydto.Description,
            Name=GetCategorydto.Name
            
            };

            return View(UpdateCategoryDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(UpdateCategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateAsync(categoryDto);
                return RedirectToAction(nameof(CategoryIndex));
            }
            return View(categoryDto);
        }

        // GET: Admin/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = await productService.GetByIdWithDetailsAsync(Id);
            return View(product);
        }

        // POST: Admin/DeleteProduct/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id,string ImageUrl)
        {
            imageService.Delete(ImageUrl);
            await productService.DeleteByIdAsync(Id);
            return RedirectToAction(nameof(ProductIndex));
        }

        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var category = await categoryService.GetByIdAsync(Id);
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int Id)
        {
            await categoryService.DeleteByIdAsync(Id);
            return RedirectToAction(nameof(CategoryIndex));
        }

        public async Task<IActionResult> OrderIndex() {

            var orders = await orderService.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int Id) {

            var order = await orderService.GetByIdAsync(Id);
            return View(order);
        }

        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var Order = await orderService.GetByIdAsync(Id);
            return View(Order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderConfirmed(int Id)
        {
            await orderService.DeleteByIdAsync(Id);
            return RedirectToAction(nameof(OrderIndex));
        }



    }
}
