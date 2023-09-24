using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Abstract.Domains;
using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
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
        public async Task<TEntity> FindAsync(params int[] keys)

            => await _context.Set<TEntity>().FindAsync(keys);

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

        public bool Remove(TEntity entity)
        {
            EntityEntry entityEntry = _context.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {

            _context.Set<TEntity>().RemoveRange(entity);

        }

        /// <summary>
        /// Check if any entity exists with given primary key
        /// </summary>
        /// <param name="pK"></param>
        /// <returns></returns>
        public async Task<bool> Any<TEntityWithHasOwnPk>(int pK)
            where TEntityWithHasOwnPk : class, IEntityWithHasOwnPk, new()
            => await _context.Set<TEntityWithHasOwnPk>().AnyAsync(e => e.Id.Equals(pK));

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
