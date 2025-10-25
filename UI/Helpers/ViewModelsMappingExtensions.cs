using BLL.DTOs.Product;
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
    }
}
