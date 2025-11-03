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
        public IproductRepo Products { get; }
        public IOrderRepo Orders { get; }
        public ICategoryRepo Categories { get; }
        public IOrderProductsRepo Orderproducts { get; }


        public UnitOfWork(ApplicationDbContext _context, IOrderRepo _orders,
                ICategoryRepo _categories,IproductRepo _products, IOrderProductsRepo _orderproducts)
        {
            context = _context;
            Orders = _orders;
            Categories = _categories;
            Products = _products;
            Orderproducts = _orderproducts;
        }


        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            
        }

    }
}
