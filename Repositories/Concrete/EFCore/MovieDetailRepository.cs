using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class MovieDetailRepository : BaseRepository<MovieDetail>, IMovieDetailRepository
    {
        public MovieDetailRepository(MovieContext context) : base(context)
        {

        }
    }
}