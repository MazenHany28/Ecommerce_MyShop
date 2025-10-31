using BLL.DTOs.Products;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Categories
{
    public static class DTOsExtensionMethods
    {
        public static GetCategoryDto ToGetCategoryDto(this Category category) {

            return new GetCategoryDto()
            {
                Id = category.Id,
                Name= category.Name,
                Description= category.Description,
                NumberOfProducts= category.products.Count()
            };
        }

        public static Category ToCategory(this AddCategoryDto dto) {

            return new Category()
            {
                Name=dto.Name,
                Description=dto.Description,
            };
        }

        public static Category ToCategory(this UpdateCategoryDto dto)
        {

            return new Category()
            {
                Id=dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }

        public static void FromUpdateCategoryDto(this Category category, UpdateCategoryDto dto)
        {
            category.Name = dto.Name;
            category.Description = dto.Description;
        }

    }
}
