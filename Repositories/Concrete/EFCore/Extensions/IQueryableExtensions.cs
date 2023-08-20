using Microsoft.EntityFrameworkCore;
using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using Models.Concrete.RequestFeatures;

namespace Repositories.Concrete.EFCore.Extensions
{
    public static class IQueryableExtensions

    {
        public async static Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> source, RequestParameters requestParameters)
            where T : class, IEntity, new()
        {
            int count = source.Count();

            var result = await source.Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
                                     .Take(requestParameters.PageSize)
                                     .ToListAsync();

            return await PagedList<T>.AsPaged(result, count, requestParameters);
        }
    }
}
