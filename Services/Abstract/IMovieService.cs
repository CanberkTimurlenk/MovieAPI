using Models.Abstract.RequestFeatures;
using Models.Concrete.Entities;
using Models.Concrete.RequestFeatures;

namespace Services.Abstract
{
    public interface IMovieService
    {
        Task<PagedList<Movie>> GetMoviesByTitleAsync(string title, RequestParameters requestParameters);
    }
}
