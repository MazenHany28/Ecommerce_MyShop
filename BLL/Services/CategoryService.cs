using BLL.DTOs.Categories;
using BLL.DTOs.Products;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork UoW;

        public CategoryService(IUnitOfWork _UoW)
        {
            UoW = _UoW;
        }

        public async Task AddAsync(AddCategoryDto categoryDto)
        {
            var category = categoryDto.ToCategory();
            await UoW.Categories.AddAsync(category);
            await UoW.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int Id)
        {
            var category = await UoW.Categories.GetByIdAsync(Id);
            if (category != null)
            {
                UoW.Categories.Delete(category);
                await UoW.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Category with this Id is not found");
            }
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            var categories = await UoW.Categories.GetAllAsync(c=>c.Include(c=>c.products));
            return categories.Select(c => c.ToGetCategoryDto());
        }

        public async Task<IEnumerable<string>> GetNamesAsync()
        {
            var categories = await UoW.Categories.GetAllAsync();
            return categories.Select(c => c.Name);
        }

        public async Task<GetCategoryDto?> GetByIdAsync(int Id)
        {
            var category = await UoW.Categories.GetByIdWithDetailsAsync(Id);
            if (category != null)
                return category.ToGetCategoryDto();
            else
                throw new NotFoundException($"No element with this Id is found");
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = await UoW.Categories.GetByIdAsync(categoryDto.Id);
            if (category == null)
                throw new NotFoundException($"No category with this Id is found");
            category.FromUpdateCategoryDto(categoryDto);
            UoW.Categories.Update(category);
            await UoW.SaveChangesAsync();
        }

    }
}
