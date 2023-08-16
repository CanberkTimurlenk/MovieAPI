using Microsoft.EntityFrameworkCore;
using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using Models.Concrete.RequestFeatures;
using Repositories.Concrete.EFCore.Contexts;
using Repositories.Concrete.EFCore.Extensions;
using System.Linq.Expressions;

namespace Repositories.Abstract.Base.EFCore
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity, new()
    {
        protected readonly MovieContext _context;

        public BaseRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<T> FindAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<PagedList<T>> GetAllByConditionAsync(Expression<Func<T, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {
            var data = await GetAllByConditionAsQueryable(filter, trackChanges)
                                .Paginate(requestParameters)
                                .ToListAsync();

            return PagedList<T>.ToPagedList(data, requestParameters);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool trackChanges)
            => await GetAllAsQueryable(trackChanges).Where(filter).SingleOrDefaultAsync();

        public async Task CreateAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public async Task<int> DeleteByConditionAsync(Expression<Func<T, bool>> filter)
            => await GetAllByConditionAsQueryable(filter, true).ExecuteDeleteAsync();  //  EF CORE 7 


        protected IQueryable<T> GetAllAsQueryable(bool trackChanges)
            => trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();

        protected IQueryable<T> GetAllByConditionAsQueryable(Expression<Func<T, bool>> filter, bool trackChanges)
            => GetAllAsQueryable(trackChanges).Where(filter);


    }
}
