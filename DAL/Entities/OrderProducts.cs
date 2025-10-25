using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderProducts:IEntity
    {
        [Key]
        public int Id { get; set; }
        //fk
        [Required]
        public int OrderId { get; set; }
        //fk
  //[Required] allowing null values in case of deletion in the database
        public int? ProductId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Can't be negative")]
        public int Quantity { get; set; }
        //nav prop
        public virtual Product? product { get; set; }
        public virtual Order? order { get; set; }
    }
}
