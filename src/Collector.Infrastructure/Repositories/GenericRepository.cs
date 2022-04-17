
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collector.Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using Collector.Domain.Base;

namespace Collector.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private protected readonly CollectorContext _dbContext;

        public GenericRepository(CollectorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> FirstOrDefaultAsync()
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            List<T> list = new List<T>();
            foreach (var entity in entities)
            {
              var res = await AddAsync(entity);
             list.Add(res);
            }
            return list;
        }

        public async Task UpdateAsync(T entity)
        {
            var oldEntity = _dbContext.Set<T>().Local.Where(e => e.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
                _dbContext.Entry<T>(oldEntity).State = EntityState.Detached;

            _dbContext.Set<T>().Attach(entity);

            await Task.FromResult(_dbContext.Entry(entity).State = EntityState.Modified);
        }

        public async Task DeleteAsync(T entity)
        {
           await Task.FromResult(_dbContext.Set<T>().Remove(entity));
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext
                 .Set<T>()
                 .Where(expression)
                 .ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext
                    .Set<T>()
                    .AsQueryable();

        }


    }
}