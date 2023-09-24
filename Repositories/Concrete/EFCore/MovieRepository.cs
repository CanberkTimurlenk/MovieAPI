using Microsoft.EntityFrameworkCore;
using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.Entities.Junctions;
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
                                                .SelectMany(l => l.Movies)
                                                .Select(m => m.Movie);


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

        public async Task<PagedList<Movie>> GetMoviesByGenreAsync(Expression<Func<Genre, bool>> filter, RequestParameters requestParameters, bool trackChanges)

        {
            var query = _context.Set<Genre>().Where(filter)
                                             .SelectMany(g => g.Movies)
                                             .Select(mg => mg.Movie);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);
        }
        public async Task CreateAsync(Movie movie, List<int> genres, List<int> locations, List<int> languages)
        {
            movie.Genres = new List<MovieGenre>();
            movie.Locations = new List<MovieLocation>();
            movie.Languages = new List<MovieLanguage>();

            foreach (var genre in genres)
                movie.Genres.Add(new MovieGenre { GenreId = genre });

            foreach (var location in locations)
                movie.Locations.Add(new MovieLocation { LocationId = location });

            foreach (var language in languages)
                movie.Languages.Add(new MovieLanguage { LanguageId = language });

            await _context.Movies.AddAsync(movie);
            
        }

        /// <summary>
        /// Change tracker is enabled
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovieWithDetailsAsync(int id)
        {
            var movie = (await _context.Set<Movie>().FindAsync(id));

            if (movie is not null && movie.MovieDetail is null)
                await _context.Entry(movie).Reference(m => m.MovieDetail).LoadAsync();

            return movie;


        }

        public async Task<PagedList<Movie>> GetMoviesWithLanguagesAsync(Expression<Func<Movie, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {

            var query = _context.Set<Movie>().Where(filter)
                                             .Include(m => m.Languages);


            return trackChanges
                               ? await query.ToPagedList(requestParameters)
                               : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);

        }

        public async Task<PagedList<Movie>> GetMoviesByPersonAsync(Expression<Func<Person, bool>> filter, RequestParameters requestParameters, bool trackChanges)
        {
            var query = _context.Set<Person>().Where(filter)
                                              .SelectMany(p => p.Movies)
                                              .Select(m => m.Movie);

            return trackChanges
                                ? await query.ToPagedList(requestParameters)
                                : await query.AsNoTrackingWithIdentityResolution().ToPagedList(requestParameters);

        }



        public void RemoveRangeMovieGenres(int movieId, IEnumerable<int> genreIds)
        {

            var movieGenreList = new List<MovieGenre>();

            foreach (var id in genreIds)
                movieGenreList.Add(new MovieGenre { MovieId = movieId, GenreId = id, });

            _context.Set<MovieGenre>().RemoveRange(movieGenreList);

        }
        public void RemoveMovieGenre(int movieId, int genreId)
        {
            _context.Set<MovieGenre>().Remove(new MovieGenre { MovieId = movieId, GenreId = genreId });
        }
        public async Task AddRangeMovieGenresAsync(int movieId, IEnumerable<int> genreIds)
        {

            var movieGenreList = new List<MovieGenre>();

            foreach (var id in genreIds)
                movieGenreList.Add(new MovieGenre { MovieId = movieId, GenreId = id, });

            await _context.Set<MovieGenre>().AddRangeAsync(movieGenreList);

        }
        public async Task<IEnumerable<int>> GetGenreIds(int movieId)
        {
            return await _context.Set<MovieGenre>().Where(m => m.MovieId == movieId)
                                                   .AsNoTracking()
                                                   .Select(m => m.GenreId)
                                                   .ToListAsync();


        }


        public void RemoveRangeMovieLocations(int movieId, IEnumerable<int> locationIds)
        {

            var movieLocationList = new List<MovieLocation>();

            foreach (var id in locationIds)
                movieLocationList.Add(new MovieLocation { MovieId = movieId, LocationId = id, });

            _context.Set<MovieLocation>().RemoveRange(movieLocationList);

        }
        public void RemoveMovieLocation(int movieId, int locationId)
        {
            _context.Set<MovieLocation>().Remove(new MovieLocation { MovieId = movieId, LocationId = locationId });
        }
        public async Task AddRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIds)
        {
           
            var movieLocationList = new List<MovieLocation>();

            foreach (var id in locationIds)
                movieLocationList.Add(new MovieLocation { MovieId = movieId, LocationId = id, });

            await _context.Set<MovieLocation>().AddRangeAsync(movieLocationList);
            

        }
        public async Task<IEnumerable<int>> GetLocationIds(int movieId)
        {
            return await _context.Set<MovieLocation>().Where(m => m.MovieId == movieId)
                                                      .AsNoTracking()
                                                      .Select(m => m.LocationId)
                                                      .ToListAsync();


        }


        public void RemoveRangeMovieLanguages(int movieId, IEnumerable<int> languageIds)
        {
            var movieLanguageList = new List<MovieLanguage>();

            foreach (var id in languageIds)
                movieLanguageList.Add(new MovieLanguage { MovieId = movieId, LanguageId = id, });

            _context.Set<MovieLanguage>().RemoveRange(movieLanguageList);

        }
        public void RemoveMovieLanguage(int movieId, int languageId)
        {
            _context.Set<MovieLanguage>().Remove(new MovieLanguage { MovieId = movieId, LanguageId = languageId });
        }
        public async Task AddRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIds)
        {

            var movieLanguageList = new List<MovieLanguage>();

            foreach (var id in languageIds)
                movieLanguageList.Add(new MovieLanguage { MovieId = movieId, LanguageId = id, });

            await _context.Set<MovieLanguage>().AddRangeAsync(movieLanguageList);

        }
        public async Task<IEnumerable<int>> GetLanguageIds(int movieId)
        {
            return await _context.Set<MovieLanguage>().Where(m => m.MovieId == movieId)
                                                   .AsNoTracking() 
                                                   .Select(m => m.LanguageId)
                                                   .ToListAsync();
        }


        public void RemoveRangeMoviePersons(int movieId, IEnumerable<int> personIds)
        {

            var moviePersonList = new List<MoviePerson>();

            foreach (var id in personIds)
                moviePersonList.Add(new MoviePerson { MovieId = movieId, PersonId = id, });

            _context.Set<MoviePerson>().RemoveRange(moviePersonList);

        }
        public void RemoveMoviePerson(int movieId, int personId)
        {
            _context.Set<MoviePerson>().Remove(new MoviePerson { MovieId = movieId, PersonId = personId });
        }
        public async Task AddRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIds)
        {

            var moviePersonList = new List<MoviePerson>();

            foreach (var id in personIds)
                moviePersonList.Add(new MoviePerson { MovieId = movieId, PersonId = id, });

            await _context.Set<MoviePerson>().AddRangeAsync(moviePersonList);

        }
        public async Task<IEnumerable<int>> GetPersonIds(int movieId)
        {
            return await _context.Set<MoviePerson>().Where(m => m.MovieId == movieId)
                                                   .AsNoTracking()
                                                   .Select(m => m.PersonId)
                                                   .ToListAsync();

        }





    }
}
