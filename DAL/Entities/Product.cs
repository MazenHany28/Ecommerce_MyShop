using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Range(0,int.MaxValue,ErrorMessage ="Can't be negative")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Can't be negative")]
        public int Stock {  get; set; }
        [RegularExpression(@"^.*\.(png|jpg)$", ErrorMessage = "Invalid Image Format")]
        public string ImageUrl { get; set; } = "images/Icon.png";
        //fk
        [Required]
        public int CategoryId { get; set; }
        //fk
        [Required]
        public string AddedByUserId { get; set; }

        //nav prop
        public virtual AppIdentityUser? AddedByUser {  get; set; }
        public virtual ICollection<OrderProducts> orders { get; set; } = new HashSet<OrderProducts>();
        public virtual Category? Category { get; set; }


    }
}
