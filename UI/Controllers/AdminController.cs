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
        private readonly IImageService imageService;
        //private readonly UserManager<AppIdentityUser> userManager;

        public AdminController(IProductService _productservice,
                                ICategoryService _categoryService,
                                IImageService _imageservice
                                //UserManager<AppIdentityUser> _userManager
                                )
        {
           productService = _productservice;
           categoryService = _categoryService;
            imageService = _imageservice;
            //userManager = _userManager;
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

    }
}
