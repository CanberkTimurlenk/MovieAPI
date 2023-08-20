using Microsoft.EntityFrameworkCore;
using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
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

        public async Task<PagedList<Movie>> GetMoviesByLocationAsync(Expression<Func<Location, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {
            var query = _context.Set<Location>().Where(filter)                                                
                                                .SelectMany(l => l.Movies);


            return trackChanges 
                                ? await query.ToPagedList(requestParameters) 
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);

        }

        public async Task<PagedList<Movie>> GetMoviesWithAwardsAsync(Expression<Func<Movie, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {
            var query = _context.Set<Movie>().Where(filter)
                                             .Where(m => m.IsReleased)
                                             .Include(m => m.Awards)
                                             .ThenInclude(a => a.AwardType);


            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);
        }

        public async Task<PagedList<Movie>> GetMoviesByGenreAsync(Expression<Func<Genre, bool>> filter,RequestParameters requestParameters, bool trackChanges)
        {

            var query = _context.Set<Genre>().Where(filter)
                                             .Include(g => g.Movies)
                                             .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);


        }

        public async Task<PagedList<Movie>> GetMoviesByDirectorAsync(Expression<Func<Director, bool>> filter,RequestParameters requestParameters, bool trackChanges)
        {

            var query = _context.Set<Director>().Where(filter)
                                                .Include(g => g.Movies)
                                                .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);


        }

        public async Task<PagedList<Movie>> GetMoviesByActorAsync(Expression<Func<Actor, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {

            var query = _context.Set<Actor>().Where(filter)
                                                .Include(g => g.Movies)
                                                .SelectMany(g => g.Movies);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);


        }

        /// <summary>
        /// Change tracker is enabled
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovieWithDetailsAsync(int id)
        {
            var movie = (await _context.Set<Movie>().FindAsync(id));

            if(movie is not null && movie.MovieDetail is null)
                await _context.Entry(movie).Reference(m => m.MovieDetail).LoadAsync();

            return movie;
        }

        public async Task<PagedList<Movie>> GetMoviesWithLanguagesAsync(Expression<Func<Movie, bool>> filter,RequestParameters requestParameters, bool trackChanges)
        {
            var query = _context.Set<Movie>().Where(filter)
                                             .Include(m => m.Languages);

            return trackChanges
                               ? await query.ToPagedList(requestParameters)
                               : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);

        }

        public async Task<PagedList<Movie>> GetMoviesByPersonAsync(Expression<Func<Person, bool>> filter,RequestParameters requestParameters, bool trackChanges)
        {
            var query = _context.Set<Person>().Where(filter)
                                              .Include(p => p.MovieRoles)
                                              .ThenInclude(m => m.Movies)
                                              .SelectMany(m => m.MovieRoles)
                                              .SelectMany(a => a.Movies);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);

        }        

    }
}
