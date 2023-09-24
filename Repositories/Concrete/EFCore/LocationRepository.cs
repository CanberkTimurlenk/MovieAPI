using Microsoft.EntityFrameworkCore;
using Models.Concrete.Entities;
using Models.Concrete.Entities.Junctions;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;
using System.Linq.Expressions;

namespace Repositories.Concrete.EFCore
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {

        public LocationRepository(MovieContext context) : base(context)
        {


        }

        public async Task<IEnumerable<Location>> GetLocationsByMovie(Expression<Func<Movie, bool>> filter, bool trackChanges)
        {
            var query = _context.Movies.Where(filter)
                                       .SelectMany(m => m.Locations)
                                       .Select(ml => ml.Location);

            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();

        }


        


    }
}
