using BLL.DTOs.Product;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork UoW;
        
        public ProductService(IUnitOfWork _UoW)
        {
            UoW = _UoW; 
        }

        public async Task AddAsync(AddProductDto productDto)
        {
 
                var product =productDto.ToProduct();
                await UoW.Products.AddAsync(product);
                await UoW.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int Id)
        {
                var product = await UoW.Products.GetByIdAsync(Id);
                if (product != null)
                {
                    UoW.Products.Delete(product);
                    await UoW.SaveChangesAsync();
                }
                else {
                    throw new NotFoundException($"Product with this Id is not found");
                }
        }

        public async Task<IEnumerable<GetProductDto>> FilterAsync(Func<IQueryable<Product>, IQueryable<Product>> Query)
        {
                var filteredproducts = await UoW.Products.GetAllAsync(Query);
                return filteredproducts.Select(p=>p.ToGetProductDto());
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
                var products = await UoW.Products.GetAllAsync();
                return products.Select(p=>p.ToGetProductDto());
        }

        public async Task<IEnumerable<GetProductWithDetailsDto>> GetAllWithDetailsAsync()
        {

            var products = await UoW.Products.GetAllAsync(
                                                             p=>p
                                                             .Include(p=>p.AddedByUser)
                                                             .Include(p=>p.Category)
                                                             );
            return products.Select(p => p.ToGetProductWithDetailsDto());

        }

        public async Task<GetProductDto?> GetByIdAsync(int Id)
        {

                var product = await UoW.Products.GetByIdAsync(Id);
                if (product != null)
                    return product.ToGetProductDto();
                else
                    throw new NotFoundException($"No element with this Id is found");

        }

        public async Task<GetProductWithDetailsDto?> GetByIdWithDetailsAsync(int Id)
        {
                var product = await UoW.Products.GetByIdWithDetailsAsync(Id);
                if (product != null)
                    return product.ToGetProductWithDetailsDto();
                else
                    throw new NotFoundException($"No product with this Id is found");
        }


        public async Task UpdateAsync(UpdateProductDto productDto)
        {
                var product = await  UoW.Products.GetByIdAsync(productDto.Id);
                if (product==null)
                    throw new NotFoundException($"No product with this Id is found");
                product.FromUpdateProductDto(productDto);
                UoW.Products.Update(product);
                await UoW.SaveChangesAsync();
        }

        public async Task<(IEnumerable<GetProductDto>,int TotalProducts,int maxProduct,int minProduct)> GetFilteredAsync(ProductFiltersDto filters)
        {
            var query = UoW.Products.Query();

            //Max and Min price
            var MaxProduct = (int)Math.Ceiling(await query.MaxAsync(p => p.Price));

            var MinProduct =(int)Math.Floor(await query.MinAsync(p => p.Price)) ;
            //include category
            query = query.Include(p => p.Category);

            // --- Filtering ---
            if (!string.IsNullOrEmpty(filters.SearchTerm))
                query = query.Where(p => p.Name.Contains(filters.SearchTerm));

            if (!string.IsNullOrEmpty(filters.Category) && filters.Category != "all")
                query = query.Where(p => p.Category!.Name == filters.Category);

            if (filters.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filters.MinPrice.Value);

            if (filters.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);

            // --- Sorting ---
            query = filters.SortBy switch
            {
                "price-asc" => query.OrderBy(p => p.Price),
                "price-desc" => query.OrderByDescending(p => p.Price),
                "name-asc" => query.OrderBy(p => p.Name),
                "name-desc" => query.OrderByDescending(p => p.Name),
                _ => query.OrderByDescending(p => p.Id)
            };

            // --- Count before paging ---
            var totalCount = await query.CountAsync();

            // --- Paging ---
            query = query.Skip((filters.Page - 1) * filters.PageSize).Take(filters.PageSize);

            var products = await query.ToListAsync();

            
            var afterFilter = query.Count();
            Console.WriteLine($" After filter: {afterFilter}, Page: {filters.Page}, PageSize: {filters.PageSize}");


            return (products.Select(p => p.ToGetProductDto()), totalCount,MaxProduct,MinProduct);
        }

    }
}
