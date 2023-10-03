using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Repositories.Abstract.Base;
using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<PagedList<Movie>> GetMoviesByLocationAsync(Expression<Func<Location, bool>> filter, MovieParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesWithAwardsAsync(Expression<Func<Movie, bool>> filter, MovieParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByGenreAsync(Expression<Func<Genre, bool>> filter, MovieParameters requestParameters, bool trackChanges);
        Task<Movie> GetMovieWithDetailsAsync(int id);
        Task<PagedList<Movie>> GetAllMoviesAsync(Expression<Func<Movie, bool>> filter, MovieParameters movieParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesWithLanguagesAsync(Expression<Func<Movie, bool>> filter, MovieParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByPersonAsync(Expression<Func<Person, bool>> filter, MovieParameters requestParameters, bool trackChanges);
        Task CreateAsync(Movie movie, List<int> genres, List<int> locations, List<int> languages);


        void RemoveRangeMovieGenres(int movieId, IEnumerable<int> genreIds);
        void RemoveMovieGenre(int movieId, int genreId);
        Task AddRangeMovieGenresAsync(int movieId, IEnumerable<int> genreIds);
        Task<IEnumerable<int>> GetGenreIds(int movieId);

        void RemoveRangeMovieLocations(int movieId, IEnumerable<int> locationIds);
        void RemoveMovieLocation(int movieId, int locationId);
        Task AddRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIds);
        Task<IEnumerable<int>> GetLocationIds(int movieId);

        void RemoveRangeMovieLanguages(int movieId, IEnumerable<int> languageIds);
        void RemoveMovieLanguage(int movieId, int languageId);
        Task AddRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIds);
        Task<IEnumerable<int>> GetLanguageIds(int movieId);

        void RemoveRangeMoviePersons(int movieId, IEnumerable<int> personIds);
        void RemoveMoviePerson(int movieId, int personId);
        Task AddRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIds);
        Task<IEnumerable<int>> GetPersonIds(int movieId);





    }
}
