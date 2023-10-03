using Models.Concrete.Entities;
using System.Linq.Dynamic.Core;

namespace Repositories.Concrete.EFCore.Extensions
{
    public static class MovieRepositoryExtensions
    {
        public static IQueryable<Movie> Sort(this IQueryable<Movie> movie, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return movie;

            var orderQuery = OrderQueryBuilder<Movie>.CreateQueryString(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return movie.OrderBy(m => m.Id);

            return movie.OrderBy(orderQuery);

        }
    }
}
