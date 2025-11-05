using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Products
{
    public static class DTOsExtensionMethods
    {

        public static GetProductDto ToGetProductDto(this Product product) {

            GetProductDto dto = new GetProductDto() {
             Id =product.Id,
             Name=product.Name,
        Description =product.Description,
         Price =product.Price,
         Stock =product.Stock,
         ImageUrl =product.ImageUrl,
        CategoryId =product.CategoryId,
         AddedByUserId =product.AddedByUserId
                 };

            return dto;
        }

        public static GetProductWithDetailsDto ToGetProductWithDetailsDto(this Product product)
        {

            GetProductWithDetailsDto dto = new GetProductWithDetailsDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                AddedByUserId = product.AddedByUserId,
                AddedByUser=product.AddedByUser.UserName,
                Category=product.Category.Name ,
                CategoryDescription=product.Category.Description,
                QuantitySold=product.orders.Sum(o => o.Quantity), 
                NumberOfOrders=product.orders.Count()
                };

            return dto;
        }

        public static Product ToProduct(this AddProductDto dto) {

            Product product = new Product()
            {               
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                AddedByUserId = dto.AddedByUserId
            };

            return product;

        }

        public static Product ToProduct(this UpdateProductDto dto)
        {

            Product product = new Product()
            {
                Id= dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                AddedByUserId = dto.AddedByUserId
            };

            return product;

        }

        public static void FromUpdateProductDto(this Product product, UpdateProductDto dto)
        {
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;
            product.AddedByUserId = dto.AddedByUserId;
        }


    }
}
