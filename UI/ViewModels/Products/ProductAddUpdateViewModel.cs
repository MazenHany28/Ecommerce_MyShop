using System.ComponentModel.DataAnnotations;

namespace UI.ViewModels.Products
{
    public class ProductAddUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Can't be negative")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Can't be negative")]
        public int Stock { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }

        public string AddedByUserId { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }
    }
}
