using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {

            await dbSet.AddAsync(entity);
  
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>,IQueryable<T>>? Query = null)
        {
            IQueryable<T> query = dbSet;
            if (Query != null)
                query = Query(query);
            return await query.ToListAsync();

        }

        public async Task<T?> GetByIdAsync(int Id)
        {
            return await dbSet.FindAsync(Id);
          
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);

        }


        public IQueryable<T>  Query() {
            return  dbSet.AsQueryable();
        } 
    }

}
