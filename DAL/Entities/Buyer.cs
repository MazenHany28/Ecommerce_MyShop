using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Buyer : AppIdentityUser, IEntity
    {
        public string? Organization {  get; set; }
    }
}
