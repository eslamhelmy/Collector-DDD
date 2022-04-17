using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Collector.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FirstOrDefaultAsync();
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        IQueryable<T> GetAll();
    }
}