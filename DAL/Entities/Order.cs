using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order:IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total {  get; set; }
        [Required]
        public string PaymentProvider { get; set; } = string.Empty;
        [Required]
        public string PaymentTransactionId { get; set; } = string.Empty;
        //fk
        [Required]
        public string CustomerId { get; set; }
        //nav prop
        public virtual Customer? customer { get; set; }
        public virtual ICollection<OrderProducts> products { get; set; } = new HashSet<OrderProducts>();
    }
}
