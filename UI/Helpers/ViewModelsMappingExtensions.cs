using BLL.DTOs.Products;
using UI.ViewModels.Products;

namespace UI.Helpers
{
    public static class ViewModelsMappingExtensions
    {
        public static ProductFiltersDto toFilters(this ProductListViewModel model) {

            return new ProductFiltersDto()
            {

                 SearchTerm   =model.SearchTerm   ,
                 Category     =model.Category     ,
                 MinPrice     =model.MinPrice     ,
                 MaxPrice     =model.MaxPrice     ,
                 SortBy       =model.SortBy       ,
                 Page         =model.Page         ,
                 PageSize     =model.PageSize     
   
             };


        }

        public static ProductDetailsViewModel ToProductDetailsViewModel(this GetProductWithDetailsDto dto) {

            return new ProductDetailsViewModel()
            {
                Id= dto.Id ,
                Name=dto.Name ,
                Description=dto.Description ,
                Price=dto.Price ,
                ImageUrl=dto.ImageUrl ,
                Category=dto.Category ,
                CategoryDescription=dto.CategoryDescription,
                Stock=dto.Stock 
            };
         
        }

        public static AddProductDto ToAddProductDto(this ProductAddUpdateViewModel model) {
            return new AddProductDto()
            {
                Name= model.Name ,
                Description= model.Description ,
                Price= model.Price ,
                ImageUrl= model.ImageUrl ,
                Stock=model.Stock ,
                CategoryId=model.CategoryId ,
                AddedByUserId=model.AddedByUserId 
            };
        
        }

        public static UpdateProductDto ToUpdateProductDto(this ProductAddUpdateViewModel model)
        {
            return new UpdateProductDto()
            {
                Id= model.Id ,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                AddedByUserId = model.AddedByUserId
            };

        }

        public static ProductAddUpdateViewModel ToProductAddUpdateViewModel(this GetProductWithDetailsDto dto) {
            return new ProductAddUpdateViewModel() {
                Id = dto.Id,
                Name = dto.Name,
                Description=dto.Description,
                Price=dto.Price,
                Stock=dto.Stock,
                ImageUrl=dto.ImageUrl,
                CategoryId=dto.CategoryId,
                AddedByUserId=dto.AddedByUserId
            };
        
        }
    }
}
