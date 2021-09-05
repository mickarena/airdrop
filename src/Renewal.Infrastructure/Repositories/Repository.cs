using Microsoft.EntityFrameworkCore;
using Renewal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Renewal.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RenewalDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(RenewalDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual TEntity Get(string id)
        {
            return _entities.Find(id);
        }

        public virtual IQueryable<TEntity> List()
        {
            return _entities.AsQueryable<TEntity>();
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return  entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(string id)
        {
            return await _entities.FindAsync(id);
        }
    }
}
