using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IproductRepo : IRepository<Product> { 
    
    
    }

    public class ProductRepo : GenericRepository<Product>, IproductRepo
    {
        public ProductRepo(ApplicationDbContext _context) : base(_context)
        {
        }

    }
}
