using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MovieManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PagedList<Movie>> GetMoviesByTitleAsync(string title, RequestParameters requestParameters)

            => await _repositoryManager.Movie.GetAllByConditionAsync(m => m.Title.Contains(title), requestParameters, false);

        public async Task<PagedList<Movie>> GetMoviesByIsReleasedAsync(bool isReleased, RequestParameters requestParameters)

            => await _repositoryManager.Movie.GetAllByConditionAsync(m => m.IsReleased.Equals(isReleased), requestParameters, false);

        public async Task<PagedList<Movie>> GetMoviesByDurationIntervalAsync(int minDuration, int maxDuration, RequestParameters requestParameters)

           => await _repositoryManager.Movie.GetAllByConditionAsync(
                        m => m.DurationAsMinute > minDuration && m.DurationAsMinute < maxDuration,
                        requestParameters,
                        false
                        );

        public async Task<PagedList<Movie>> GetMoviesByActorNameAsync(string name, RequestParameters requestParameters)

           => await _repositoryManager.Movie.GetMoviesByActorAsync(a => a.Name.Contains(name), requestParameters, false);

        public async Task<int> ExecuteDeleteUnreleased()

           => await _repositoryManager.Movie.DeleteByConditionAsync(a => a.IsReleased.Equals(false));

        public async Task<Movie> FindByIdAsync(int id)

           => await _repositoryManager.Movie.FindAsync(id);

        public async Task<PagedList<Movie>> GetMoviesWithAwardsByMovieIdAsync(int id, RequestParameters requestParameters)

             => await _repositoryManager.Movie.GetMoviesWithAwardsAsync(m => m.Id.Equals(id), requestParameters, false);

        public async Task<PagedList<Movie>> GetMoviesByGenreIdAsync(int id, RequestParameters requestParameters)

            => await _repositoryManager.Movie.GetMoviesByGenreAsync(g => g.Id.Equals(id), requestParameters, false);

        public async Task<PagedList<Movie>> GetMoviesByLocationNameAsync(string name, RequestParameters requestParameters)

            => await _repositoryManager.Movie.GetMoviesByLocationAsync(l => l.Name.Contains(name), requestParameters, false);

        public async Task<PagedList<Movie>> GetMoviesByDirectorId(string id, RequestParameters requestParameters)

            => await _repositoryManager.Movie.GetMoviesByDirectorAsync(d => d.Id.Equals(id), requestParameters, false);

        public async Task<(int id, bool operationResult)> CreateAsync(Movie movie)
        {
            var result = await _repositoryManager.Movie.CreateAsync(movie);
            await _repositoryManager.SaveAsync();
            
            return (movie.Id,result);

        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            var result = _repositoryManager.Movie.Update(movie);
            await _repositoryManager.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Movie movie)
        {
            var result = _repositoryManager.Movie.Delete(movie);
            await _repositoryManager.SaveAsync();

            return result;
        }


        public async Task GetMoviesByActorName(string name, RequestParameters requestParameters)

        => await _repositoryManager.Movie.GetMoviesByActorAsync(a => a.Name.Contains(name), requestParameters, false);

        public async Task GetMovieWithDetailsByMovieId(int id)

            => await _repositoryManager.Movie.GetMovieWithDetailsAsync(id);



    }
}