using Microsoft.EntityFrameworkCore;
using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base;
using Repositories.Concrete.EFCore.Contexts;
using Repositories.Concrete.EFCore.Extensions;
using System.Linq.Expressions;

namespace Repositories.Concrete.EFCore
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        


        public MovieRepository(MovieContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Movie>> GetMoviesByLocation(Expression<Func<Location, bool>> filter, bool trackChanges)
        {
            var query = _context.Set<Location>().Where(filter)                                                
                                                .SelectMany(l => l.Movies);


            return trackChanges 
                                ? await query.ToListAsync() 
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();

        }

        public async Task<IEnumerable<Movie>> GetMoviesWithAwards(Expression<Func<Movie, bool>> filter, bool trackChanges)
        {
            var query = _context.Set<Movie>().Where(filter)
                                             .Where(m => m.IsReleased)
                                             .Include(m => m.Awards)
                                             .ThenInclude(a => a.AwardType);


            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(Expression<Func<Genre, bool>> filter, bool trackChanges)
        {

            var query = _context.Set<Genre>().Where(filter)
                                             .Include(g => g.Movies)
                                             .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();


        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirector(Expression<Func<Director, bool>> filter, bool trackChanges)
        {

            var query = _context.Set<Director>().Where(filter)
                                                .Include(g => g.Movies)
                                                .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();


        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirector(Expression<Func<Actor, bool>> filter, bool trackChanges)
        {

            var query = _context.Set<Actor>().Where(filter)
                                                .Include(g => g.Movies)
                                                .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();


        }

        public async Task<IEnumerable<Movie>> GetMovieDetails(Expression<Func<Movie, bool>> filter, bool trackChanges)
        {
            var query = _context.Set<Movie>().Where(filter)
                                             .Include(m => m.MovieDetail);

            return trackChanges
                                 ? await query.ToListAsync()
                                 : await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesWithLanguages(Expression<Func<Movie, bool>> filter, bool trackChanges)
        {
            var query = _context.Set<Movie>().Where(filter)
                                             .Include(m => m.Languages);

            return trackChanges
                               ? await query.ToListAsync()
                               : await query.AsNoTrackingWithIdentityResolution().ToListAsync();

        }

        public async Task<IEnumerable<Movie>> GetMoviesByPerson(Expression<Func<Person, bool>> filter, bool trackChanges)
        {
            var query = _context.Set<Person>().Where(filter)
                                               .Include(p => p.MovieRoles)
                                               .ThenInclude(m => m.Movies)
                                               .SelectMany(m => m.MovieRoles)
                                               .SelectMany(a => a.Movies);

            return trackChanges
                                ? await query.ToListAsync()
                                : await query.AsNoTrackingWithIdentityResolution().ToListAsync();

        }

      





    }
}
