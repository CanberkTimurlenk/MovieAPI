using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using Models.Concrete.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Abstract.Base
{
    public interface IBaseRepository<T>
        where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool trackChanges);
        Task<T> FindAsync(int id);
        Task<PagedList<T>> GetAllByConditionAsync(Expression<Func<T, bool>> filter, RequestParameters requestParameters, bool trackChanges);


        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> DeleteByConditionAsync(Expression<Func<T, bool>> filter);

    }
}
