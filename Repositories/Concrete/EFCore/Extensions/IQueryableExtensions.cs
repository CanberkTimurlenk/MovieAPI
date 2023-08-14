using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;


namespace Repositories.Concrete.EFCore.Extensions
{
    public static class IQueryableExtensions

    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, RequestParameters requestParameters)
            where T : class, IEntity, new()

                => source
                         .Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
                         .Take(requestParameters.PageSize);


    }


}
