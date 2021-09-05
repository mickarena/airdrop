using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Renewal.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        TEntity Get(string id);
        IQueryable<TEntity> List();


        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(string id);
    }
}
