using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Products
{
    public class ProductFiltersDto
    {
        // Filters
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // Sorting
        public string? SortBy { get; set; }

        // Pagination
        public int Page { get; set; } = 1;
 
        public int PageSize { get; set; } = 12;

    }
}
