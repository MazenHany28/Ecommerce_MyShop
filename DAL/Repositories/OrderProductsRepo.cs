using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IOrderProductsRepo : IRepository<OrderProducts>
    {


    }

    public class OrderProductsRepo : GenericRepository<OrderProducts>, IOrderProductsRepo
    {
        public OrderProductsRepo(ApplicationDbContext _context) : base(_context)
        {
        }

    }
}
