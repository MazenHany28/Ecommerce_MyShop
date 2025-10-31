using BLL.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {

        Task AddAsync(AddCategoryDto categoryDto);
        Task DeleteByIdAsync(int Id);
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto?> GetByIdAsync(int Id);
        Task UpdateAsync(UpdateCategoryDto categoryDto);
        Task<IEnumerable<string>> GetNamesAsync();

    }
}
