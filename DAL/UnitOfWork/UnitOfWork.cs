using DAL.Data;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IproductRepo products;
        public IOrderRepo orders;
        public ICategoryRepo categories;

        public UnitOfWork(ApplicationDbContext _context, IOrderRepo _orders,
                ICategoryRepo _categories,IproductRepo _products)
        {
            context = _context;
            orders = _orders;
            categories = _categories;
            products = _products;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
