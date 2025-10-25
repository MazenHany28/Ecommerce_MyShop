using BLL.DTOs.Product;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {

        Task AddAsync(AddProductDto productDto);
        Task DeleteByIdAsync(int Id);
        Task<IEnumerable<GetProductDto>> FilterAsync(Func<IQueryable<Product>, IQueryable<Product>> Query);
        Task<IEnumerable<GetProductDto>> GetAllAsync();
        Task<IEnumerable<GetProductWithDetailsDto>> GetAllWithDetailsAsync();
        Task<GetProductDto?> GetByIdAsync(int Id);
        Task<GetProductWithDetailsDto?> GetByIdWithDetailsAsync(int Id);
        Task UpdateAsync(UpdateProductDto productDto);
        Task<(IEnumerable<GetProductDto>, int TotalProducts, int maxProduct, int minProduct)> GetFilteredAsync(ProductFiltersDto filters);

    }
}
