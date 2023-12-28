using System.Linq.Expressions;

namespace KartuliAPI2.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void Save();

        Task SaveAsync();
    }
}
