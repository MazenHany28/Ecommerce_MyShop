using BLL.DTOs.Product;

namespace UI.ViewModels.Products
{
    public class ProductListViewModel
    {
        // Data
        public IEnumerable<GetProductDto> Products { get; set; } = Enumerable.Empty<GetProductDto>();

        // Filters
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // Sorting
        public string? SortBy { get; set; }

        // Pagination
        public int Page { get; set; } = 1;
        public int TotalProducts { get; set; }
        public int PageSize { get; set; } = 12;

        public int TotalPages => (int)Math.Ceiling((decimal)TotalProducts / PageSize);
        public int MaxProduct {  get; set; }
        public int MinProduct { get; set; }
    }

}
