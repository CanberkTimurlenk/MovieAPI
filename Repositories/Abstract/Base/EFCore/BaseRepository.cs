using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Repositories.Concrete.EFCore.Contexts;
using Repositories.Concrete.EFCore.Extensions;
using System.Linq.Expressions;

namespace Repositories.Abstract.Base.EFCore
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        protected readonly MovieContext _context;

        public BaseRepository(MovieContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Change tracker is enabled
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(int id)

            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<PagedList<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> filter, RequestParameters requestParameters, bool trackChanges)

        => await GetAllByConditionAsQueryable(filter, trackChanges)
                                    .ToPagedList(requestParameters);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool trackChanges)
            
            => await GetAllAsQueryable(trackChanges).Where(filter).SingleOrDefaultAsync();


        public async Task<bool> CreateAsync(TEntity entity)
        {
            EntityEntry entityEntry = await _context.Set<TEntity>().AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(TEntity entity)
        {
            EntityEntry entityEntry = _context.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry entityEntry = _context.Set<TEntity>().Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> DeleteByConditionAsync(Expression<Func<TEntity, bool>> filter)
            
            => await GetAllByConditionAsQueryable(filter, true).ExecuteDeleteAsync();  //  EF CORE 7 


        protected IQueryable<TEntity> GetAllAsQueryable(bool trackChanges)
            
            => trackChanges
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().AsNoTracking();

        protected IQueryable<TEntity> GetAllByConditionAsQueryable(Expression<Func<TEntity, bool>> filter, bool trackChanges)
            
            => GetAllAsQueryable(trackChanges).Where(filter);


    }
}
