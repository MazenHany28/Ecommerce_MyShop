using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IOrderRepo : IRepository<Order>
    {


    }

    public class OrderRepo : GenericRepository<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext _context) : base(_context)
        {
        }

    }
}
