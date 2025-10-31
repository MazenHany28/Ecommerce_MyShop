using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICategoryRepo : IRepository<Category>
    {


    }

    public class CategoryRepo : GenericRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext _context) : base(_context)
        {

        }

    }
}
