using Models.Concrete.Entities;
using System.Linq.Dynamic.Core;

namespace Repositories.Concrete.EFCore.Extensions
{
    public static class MovieRepositoryExtensions
    {
        public static IQueryable<Movie> Sort(this IQueryable<Movie> movie, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return movie.OrderBy(m => m.Id); 

            var orderQuery = OrderQueryBuilder<Movie>.CreateQueryString(orderByQueryString);

            if (string.IsNullOrEmpty(orderQuery))
                return movie.OrderBy(m => m.Id);

            return movie.OrderBy(orderQuery);

        }
    }
}
