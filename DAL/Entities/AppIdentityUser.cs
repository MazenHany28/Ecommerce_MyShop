using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AppIdentityUser:IdentityUser,IEntity
    {
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;
        public DateTime JoinDate {  get; set; }=DateTime.Now;
        [RegularExpression("^(M|F)$",ErrorMessage ="Gender can only be M or F")]
        public char Gender { get; set; }

        //nav prop
        public virtual ICollection<Product> products {  get; set; } =new HashSet<Product>();
    }
}
