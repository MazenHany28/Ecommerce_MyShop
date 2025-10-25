using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IproductRepo : IRepository<Product> {
      
        Task<Product?> GetByIdWithDetailsAsync(int Id);
    }

    public class ProductRepo : GenericRepository<Product>, IproductRepo
    {
        public ProductRepo(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task<Product?> GetByIdWithDetailsAsync(int Id) {

            return await dbSet.Include("Category")
                 .Include("AddedByUser")
                 .FirstOrDefaultAsync(p => p.Id == Id);

        }


    }
}
