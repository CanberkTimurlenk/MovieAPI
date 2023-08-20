using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;
using Repositories.Abstract.Base;
using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {

        Task<PagedList<Movie>> GetMoviesByLocationAsync(Expression<Func<Location, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesWithAwardsAsync(Expression<Func<Movie, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByGenreAsync(Expression<Func<Genre, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByDirectorAsync(Expression<Func<Director, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByActorAsync(Expression<Func<Actor, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<Movie> GetMovieWithDetailsAsync(int id);
        Task<PagedList<Movie>> GetMoviesWithLanguagesAsync(Expression<Func<Movie, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<Movie>> GetMoviesByPersonAsync(Expression<Func<Person, bool>> filter, RequestParameters requestParameters, bool trackChanges);
        
    }
}
