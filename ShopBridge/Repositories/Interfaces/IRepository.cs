using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //protected DbSet<T> Get();
        Task<T> GetById(Guid id);
        T GetByIdSynchronous(Guid id);
        ValueTask<T> FindAsync(params object[] keyValues);

        /// <summary>
        /// Do not use this unless absolutely necessary.  This is only here to be used for perfmorance reasons
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();
    }
}
