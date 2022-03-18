using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ThinkLand.DAL.Interfaces;
using ThinkLand.DAL.Data;

namespace ThinkLand.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDBContext context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;

        public GenericRepository(
            AppDBContext context,
            ILogger logger)
        {
            this.context = context;
             dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual  Task<List<T>> All()
        {
            throw new NotImplementedException("Look at GenericRepository");
        }
        
        public virtual  Task<T> GetById(Guid id)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }

        public virtual  Task<(bool IsSuccess, Exception Exception, T entity)> Add(T entity)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }

        public virtual   Task<(bool IsSuccess, Exception Exception)> Delete(Guid id)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }

        public virtual Task<(bool IsSuccess, Exception Exception, T entity)> Update(T entity)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }

        public virtual  Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }

        public virtual Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException("Look at GenericRepository");
        }
    }
}
