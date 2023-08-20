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
        Task<TEntity> FindAsync(int id);
        Task<PagedList<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> filter, RequestParameters requestParameters, bool trackChanges);       

        Task<bool> CreateAsync(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        Task<int> DeleteByConditionAsync(Expression<Func<TEntity, bool>> filter);

    }
}
