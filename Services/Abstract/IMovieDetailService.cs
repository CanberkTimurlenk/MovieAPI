using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Update.Director;
using Models.Concrete.RequestModels.Update.MovieDetailRequestForUpdate;
using Services.Concrete;

namespace Services.Abstract
{
    public interface IMovieDetailService
    {
        Task CreateAsync(MovieDetailRequestForInsertion movieDetailRequestForInsertion);
        Task<bool> DeleteByIdAsync(int id);
        Task<Location> FindByIdAsync(int id);
        Task<(MovieDetailRequestForUpdate movieDetailRequestForUpdate, MovieDetail movieDetail)> GetMovieDetailForPatchAsync(int movieId);
        Task SaveChangesForPatchAsync(MovieDetailRequestForUpdate movieDetailRequestForUpdate, MovieDetail movieDetail);
        Task UpdateAsync(int movieId, MovieDetailRequestForUpdate movieDetailRequestForUpdate);
    }
}