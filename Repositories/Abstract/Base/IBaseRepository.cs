using Models.Abstract.Domains;
using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using Models.Concrete.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Abstract.Base
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool trackChanges);
        Task<TEntity> FindAsync(params int[] keys);
        Task<PagedList<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<bool> Any<TEntityWithHasOwnPk>(int pK)
            where TEntityWithHasOwnPk : class, IEntityWithHasOwnPk, new();

        Task<bool> CreateAsync(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        Task<int> DeleteByConditionAsync(Expression<Func<TEntity, bool>> filter);

    }
}
