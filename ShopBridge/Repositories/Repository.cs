using Microsoft.EntityFrameworkCore;
using ShopBridge.Context;
using ShopBridge.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = ((DbContext)context).Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Attach(entity);
            ((DbContext)_context).Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            //_dbSet.Attach(entity);
            ((DbContext)_context).Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


        protected DbSet<T> Get()
        {
            return _dbSet;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetByIdSynchronous(Guid id)
        {
            return _dbSet.Find(id);
        }

        public async ValueTask<T> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync(System.Threading.CancellationToken.None);
        }
    }
}
