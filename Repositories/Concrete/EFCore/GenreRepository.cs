using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Genre>> GetGenreByPerson(Expression<Func<Person, bool>> filter, bool trackChanges)
        {
            // Test Required!!!
            var query = _context.Set<Person>().Where(filter)
                                              .SelectMany(p => p.Genres)
                                              .Select(g => g.Genre);


            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenreByMovie(Expression<Func<Movie, bool>> filter, bool trackChanges)
        {
            // Test Required!!!
            var query = _context.Set<Movie>().Where(filter)
                                              .SelectMany(p => p.Genres)
                                              .Select(mg => mg.Genre);


            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();

        }

    }
}
