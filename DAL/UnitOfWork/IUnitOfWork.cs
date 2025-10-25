using DAL.Data;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IproductRepo Products{ get; }
        public IOrderRepo Orders { get; }
        public ICategoryRepo Categories { get; }

        Task SaveChangesAsync();
    }
}
