using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Products
{
    public class GetProductWithDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string AddedByUserId { get; set; }
        [Display(Name="Added By User")]
        public string AddedByUser {  get; set; }
        public string Category {  get; set; }
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
        [Display(Name = "Quantity Sold")]
        public int QuantitySold { get; set; }
        [Display(Name = "Number Of Orders")]
        public int NumberOfOrders { get; set; }
    }
}
