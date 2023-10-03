using Microsoft.AspNetCore.JsonPatch;
using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Models.Concrete.RequestModels.Insertion.Movie;
using Models.Concrete.RequestModels.Update.Movie;
using Models.Concrete.ResponseModels.Movie;

namespace Services.Abstract
{
    public interface IMovieService
    {
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByTitleAsync(string title, MovieParameters requestParameters);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByReleaseStatusAsync(bool isReleased, MovieParameters requestParameters);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByDurationIntervalAsync(int minDuration, int maxDuration, MovieParameters requestParameters);
        Task<(IEnumerable<MovieWithAwardsResponse> movies, MetaData metaData)> GetMoviesWithAwardsByMovieIdAsync(int id, MovieParameters requestParameters);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByGenreIdAsync(int id, MovieParameters requestParameters);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByLocationNameAsync(string name, MovieParameters requestParameters);
        Task<MovieWithDetailsResponse> GetMovieWithDetailsByMovieId(int id);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByPersonId(int id, MovieParameters requestParameters);
        Task<Movie> FindByIdAsync(int id);
        Task<int> CreateAsync(MovieRequestForInsertion movie);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> ExecuteDeleteUnreleased();
        Task<MovieGenreRequestForUpdate> GetGenreIdsForPatch(int movieId);
        Task PartiallyUpdateMovieGenresAsync(int movieId, int genreIdToUpdated, IEnumerable<int> genresToUpdated);
        Task AddRangeMovieGenresAsync(int movieId, IEnumerable<int> movieGenresToAdded);
        Task DeleteRangeMovieGenresAsync(int movieId, IEnumerable<int> genreIdsToDelete);
        Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetAllMoviesAsync(MovieParameters requestParameters);

        Task<MovieLocationRequestForUpdate> GetLocationIdsForPatch(int id);
        Task PartiallyUpdateMovieLocationsAsync(int movieId, int locationIdToReplace, IEnumerable<int> locationIdsToUpdate);
        Task AddRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIdsToAdd);
        Task DeleteRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIdsToDelete);

        Task<MovieLanguageRequestForUpdate> GetLanguageIdsForPatch(int id);
        Task PartiallyUpdateMovieLanguagesAsync(int movieId, int languageIdToReplace, IEnumerable<int> languageIdsToUpdate);
        Task AddRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIdsToAdd);
        Task DeleteRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIdsToDelete);

        Task<MoviePersonRequestForUpdate> GetPersonIdsForPatch(int id);
        Task PartiallyUpdateMoviePersonsAsync(int movieId, int personIdToReplace, IEnumerable<int> personIdsToUpdate);
        Task AddRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIdsToAdd);
        Task DeleteRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIdsToDelete);
    }
}
