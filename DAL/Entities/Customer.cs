using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Customer:AppIdentityUser,IEntity
    {
        [Required]
        public string Address { get; set; } = string.Empty;

        //nav prop
        public virtual ICollection<Order> Orders { get; set; }= new HashSet<Order>();
    }
}
