using KartuliAPI2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KartuliAPI2.Repositories.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly KartuliAPI2DbContext context;

        public GenericRepository(KartuliAPI2DbContext context)
        {
            this.context = context;
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            var result = await context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await context.Set<TEntity>().AsNoTracking().ToListAsync().ConfigureAwait(false);

            return result;
        }

        public virtual async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = context.Set<TEntity>().Where(predicate).AsNoTracking();

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }

            return await result.FirstOrDefaultAsync();
        }

        public virtual IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = context.Set<TEntity>().Where(predicate).AsNoTracking();

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    result = result.Include(includeProperty);
                }
            }

            return result;
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var result = context.Set<TEntity>().Where(predicate).AsNoTracking();

            return result;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return context.Set<TEntity>().Update(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
