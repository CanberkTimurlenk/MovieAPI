using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Models.Concrete.RequestModels.Insertion.Movie;
using Models.Concrete.RequestModels.Update.Movie;
using Models.Concrete.ResponseModels.Movie;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MovieManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByTitleAsync(string title, MovieParameters requestParameters)
        {
            
            var movies = await _repositoryManager.Movie.GetAllByConditionAsync(m => m.Title.Contains(title), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);

        }

        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByReleaseStatusAsync(bool isReleased, MovieParameters requestParameters)
        {
            var movies = await _repositoryManager.Movie.GetAllByConditionAsync(m => m.IsReleased.Equals(isReleased), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);

        }

        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByDurationIntervalAsync(int minDuration, int maxDuration, MovieParameters requestParameters)
        {
            var movies = await _repositoryManager.Movie.GetAllByConditionAsync(
                             m => m.DurationAsMinute > minDuration && m.DurationAsMinute < maxDuration,
                             requestParameters,
                             false
                             );

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);
        }

        public async Task<int> ExecuteDeleteUnreleased()

           => await _repositoryManager.Movie.DeleteByConditionAsync(a => a.IsReleased.Equals(false));

        public async Task<Movie> FindByIdAsync(int id)

           => await _repositoryManager.Movie.FindAsync(id);

        public async Task<(IEnumerable<MovieWithAwardsResponse> movies, MetaData metaData)> GetMoviesWithAwardsByMovieIdAsync(int id, MovieParameters requestParameters)
        {
            var result = await _repositoryManager.Movie.GetMoviesWithAwardsAsync(m => m.Id.Equals(id), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieWithAwardsResponse>>(result), result.MetaData);
        }

        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByGenreIdAsync(int id, MovieParameters requestParameters)
        {
            var movies = await _repositoryManager.Movie.GetMoviesByGenreAsync(g => g.Id.Equals(id), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);



        }
        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByLocationNameAsync(string name, MovieParameters requestParameters)
        {
            var movies = await _repositoryManager.Movie.GetMoviesByLocationAsync(l => l.Name.Contains(name), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);
        }



        public async Task<int> CreateAsync(MovieRequestForInsertion movieRequest)
        {

            var movie = _mapper.Map<Movie>(movieRequest);

            await _repositoryManager.Movie.CreateAsync(movie, movieRequest.GenreId, movieRequest.LocationId, movieRequest.LanguageId);
            await _repositoryManager.SaveAsync();

            return (movie.Id);

        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var movie = await _repositoryManager.Movie.FindAsync(id);

            var result = _repositoryManager.Movie.Remove(movie);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<MovieWithDetailsResponse> GetMovieWithDetailsByMovieId(int id)
        {
            var result = await _repositoryManager.Movie.GetMovieWithDetailsAsync(id);

            return _mapper.Map<MovieWithDetailsResponse>(result);

        }

        public async Task<(IEnumerable<MovieResponse> movies, MetaData metaData)> GetMoviesByPersonId(int id, MovieParameters requestParameters)
        {
            var movies = await _repositoryManager.Movie.GetMoviesByPersonAsync(a => a.Id.Equals(id), requestParameters, false);

            return (_mapper.Map<IEnumerable<MovieResponse>>(movies), movies.MetaData);

        }



        public async Task<MovieGenreRequestForUpdate> GetGenreIdsForPatch(int id)
        {

            var genres = await _repositoryManager.Movie.GetGenreIds(id);
            return new MovieGenreRequestForUpdate { Genre = genres };

        }

        public async Task PartiallyUpdateMovieGenresAsync(int movieId, int genreIdToReplace, IEnumerable<int> genreIdsToUpdate)
        {

            var movieToUpdate = await _repositoryManager.Movie.FindAsync(movieId);

            _repositoryManager.Movie.RemoveMovieGenre(movieId, genreIdToReplace);

            await _repositoryManager.Movie.AddRangeMovieGenresAsync(movieId, genreIdsToUpdate);

            await _repositoryManager.SaveAsync();

        }

        public async Task AddRangeMovieGenresAsync(int movieId, IEnumerable<int> genreIdsToAdd)
        {
            await _repositoryManager.Movie.AddRangeMovieGenresAsync(movieId, genreIdsToAdd);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteRangeMovieGenresAsync(int movieId, IEnumerable<int> genreIdsToDelete)
        {
            _repositoryManager.Movie.RemoveRangeMovieGenres(movieId, genreIdsToDelete);

            await _repositoryManager.SaveAsync();
        }


        public async Task<MovieLocationRequestForUpdate> GetLocationIdsForPatch(int id)
        {
            var location = await _repositoryManager.Movie.GetLocationIds(id);
            return new MovieLocationRequestForUpdate { Location = location };
        }
        public async Task PartiallyUpdateMovieLocationsAsync(int movieId, int locationIdToReplace, IEnumerable<int> locationIdsToUpdate)
        {

            var movieToUpdate = await _repositoryManager.Movie.FindAsync(movieId);

            _repositoryManager.Movie.RemoveMovieLocation(movieId, locationIdToReplace);

            await _repositoryManager.Movie.AddRangeMovieLocationsAsync(movieId, locationIdsToUpdate);

            await _repositoryManager.SaveAsync();

        }
        public async Task AddRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIdsToAdd)
        {
            await _repositoryManager.Movie.AddRangeMovieLocationsAsync(movieId, locationIdsToAdd);

            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteRangeMovieLocationsAsync(int movieId, IEnumerable<int> locationIdsToDelete)
        {
            _repositoryManager.Movie.RemoveRangeMovieLocations(movieId, locationIdsToDelete);

            await _repositoryManager.SaveAsync();
        }


        public async Task<MovieLanguageRequestForUpdate> GetLanguageIdsForPatch(int id)
        {
            var language = await _repositoryManager.Movie.GetLanguageIds(id);
            return new MovieLanguageRequestForUpdate { Language = language };
        }
        public async Task PartiallyUpdateMovieLanguagesAsync(int movieId, int languageIdToReplace, IEnumerable<int> languageIdsToUpdate)
        {

            var movieToUpdate = await _repositoryManager.Movie.FindAsync(movieId);

            _repositoryManager.Movie.RemoveMovieLanguage(movieId, languageIdToReplace);

            await _repositoryManager.Movie.AddRangeMovieLanguagesAsync(movieId, languageIdsToUpdate);

            await _repositoryManager.SaveAsync();

        }
        public async Task AddRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIdsToAdd)
        {
            await _repositoryManager.Movie.AddRangeMovieLanguagesAsync(movieId, languageIdsToAdd);

            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteRangeMovieLanguagesAsync(int movieId, IEnumerable<int> languageIdsToDelete)
        {
            _repositoryManager.Movie.RemoveRangeMovieLanguages(movieId, languageIdsToDelete);

            await _repositoryManager.SaveAsync();
        }


        public async Task<MoviePersonRequestForUpdate> GetPersonIdsForPatch(int id)
        {
            var person = await _repositoryManager.Movie.GetPersonIds(id);
            return new MoviePersonRequestForUpdate { Person = person };
        }
        public async Task PartiallyUpdateMoviePersonsAsync(int movieId, int personIdToReplace, IEnumerable<int> personIdsToUpdate)
        {

            var movieToUpdate = await _repositoryManager.Movie.FindAsync(movieId);

            _repositoryManager.Movie.RemoveMoviePerson(movieId, personIdToReplace);

            await _repositoryManager.Movie.AddRangeMoviePersonsAsync(movieId, personIdsToUpdate);

            await _repositoryManager.SaveAsync();

        }
        public async Task AddRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIdsToAdd)
        {
            await _repositoryManager.Movie.AddRangeMoviePersonsAsync(movieId, personIdsToAdd);

            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteRangeMoviePersonsAsync(int movieId, IEnumerable<int> personIdsToDelete)
        {
            _repositoryManager.Movie.RemoveRangeMoviePersons(movieId, personIdsToDelete);

            await _repositoryManager.SaveAsync();
        }

    }
}