using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    //[Authorize(Roles ="Admin")]
    //public class AdminController : Controller
    //{
    //    private readonly IUnitOfWork UoW;

    //    public AdminController(IUnitOfWork _UoW)
    //    {
    //        UoW = _UoW;
    //    }

    //    // GET: Admin/ProductIndex
    //    public async Task<IActionResult> ProductIndex()
    //    {
    //        var applicationDbContext = _context.Products.Include(p => p.AddedByUser).Include(p => p.Category);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: Admin/ProductDetails/5
    //    public async Task<IActionResult> ProductDetails(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products
    //            .Include(p => p.AddedByUser)
    //            .Include(p => p.Category)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // GET: Admin/CreateProduct
    //    public IActionResult CreateProduct()
    //    {
    //        ViewData["AddedByUserId"] = new SelectList(_context.Users, "Id", "Id");
    //        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
    //        return View();
    //    }

    //    // POST: Admin/CreateProduct
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> CreateProduct([Bind("Id,Name,Description,Price,Stock,ImageUrl,CategoryId,AddedByUserId")] Product product)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(product);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["AddedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.AddedByUserId);
    //        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
    //        return View(product);
    //    }

    //    // GET: Admin/EditProduct/5
    //    public async Task<IActionResult> EditProduct(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products.FindAsync(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["AddedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.AddedByUserId);
    //        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
    //        return View(product);
    //    }

    //    // POST: Admin/EditProduct/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> EditProduct(int id, [Bind("Id,Name,Description,Price,Stock,ImageUrl,CategoryId,AddedByUserId")] Product product)
    //    {
    //        if (id != product.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(product);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!ProductExists(product.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["AddedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.AddedByUserId);
    //        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description", product.CategoryId);
    //        return View(product);
    //    }

    //    // GET: Admin/DeleteProduct/5
    //    public async Task<IActionResult> DeleteProduct(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products
    //            .Include(p => p.AddedByUser)
    //            .Include(p => p.Category)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // POST: Admin/DeleteProduct/5
    //    [HttpPost, ActionName("DeleteProduct")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var product = await _context.Products.FindAsync(id);
    //        if (product != null)
    //        {
    //            _context.Products.Remove(product);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool ProductExists(int id)
    //    {
    //        return _context.Products.Any(e => e.Id == id);
    //    }
    //}
}
