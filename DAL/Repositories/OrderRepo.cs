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
    public interface IOrderRepo : IRepository<Order>
    {
        Task<Order?> GetByPaymentIdAsync(string Id);
        Task<Order?> GetByIdWithDetailsAsync(int Id);
    }

    public class OrderRepo : GenericRepository<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task<Order?> GetByIdWithDetailsAsync(int Id)
        {
            return await dbSet.Include(o => o.customer)
                              .Include(o => o.products)
                              .ThenInclude(p => p.product)
                              .FirstOrDefaultAsync(o => o.Id == Id);

        }


        public async Task<Order?> GetByPaymentIdAsync(string Id)
        {
            return await dbSet.Include(o => o.customer)
                              .Include(o => o.products)
                              .ThenInclude(p => p.product)
                              .FirstOrDefaultAsync(o => o.PaymentTransactionId == Id);

        }


    }
}
