using System.Linq.Expressions;

namespace ThinkLand.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> All();
        Task<T> GetById(Guid id);
        Task<(bool IsSuccess, Exception Exception, T entity)> Add (T entity);
        Task<(bool IsSuccess, Exception Exception)> Delete(Guid id);
        Task<(bool IsSuccess, Exception Exception, T entity)> Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Guid id);
        
    }

}
