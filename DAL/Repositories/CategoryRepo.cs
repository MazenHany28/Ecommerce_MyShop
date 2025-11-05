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
    public interface ICategoryRepo : IRepository<Category>
    {
        Task<Category?> GetByIdWithDetailsAsync(int Id);

    }

    public class CategoryRepo : GenericRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext _context) : base(_context)
        {

        }

        public async Task<Category?> GetByIdWithDetailsAsync(int Id) { 
        
        return await dbSet.Include(c=>c.products).FirstOrDefaultAsync(c=>c.Id==Id);
        
        }

    }
}
