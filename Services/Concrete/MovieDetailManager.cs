using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.MovieDetailRequestForUpdate;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class MovieDetailManager : IMovieDetailService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MovieDetailManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(MovieDetailRequestForInsertion movieDetailRequestForInsertion)
        {
            var movieDetailToCreate = _mapper.Map<MovieDetail>(movieDetailRequestForInsertion);

            await _repositoryManager.MovieDetail.CreateAsync(movieDetailToCreate);
            await _repositoryManager.SaveAsync();

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var location = await _repositoryManager.Location.FindAsync(id);

            var result = _repositoryManager.Location.Remove(location);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<Location> FindByIdAsync(int id)

          => await _repositoryManager.Location.FindAsync(id);

        public async Task<(MovieDetailRequestForUpdate movieDetailRequestForUpdate, MovieDetail movieDetail)> GetMovieDetailForPatchAsync(int movieId)
        {
            var movieDetail = await _repositoryManager.MovieDetail.FindAsync(movieId);

            if (movieDetail is null)
                return (null, null);

            var movieDetailRequestForUpdate = _mapper.Map<MovieDetailRequestForUpdate>(movieDetail);
            return (movieDetailRequestForUpdate, movieDetail);
        }

        public async Task SaveChangesForPatchAsync(MovieDetailRequestForUpdate movieDetailRequestForUpdate, MovieDetail movieDetail)
        {
            _mapper.Map(movieDetailRequestForUpdate, movieDetail);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int movieId, MovieDetailRequestForUpdate movieDetailRequestForUpdate)
        {
            var movieDetail = await _repositoryManager.MovieDetail.FindAsync(movieId);

            if (movieDetail is null)
                throw new Exception();

            movieDetail = _mapper.Map<MovieDetail>(movieDetailRequestForUpdate);

            _repositoryManager.MovieDetail.Update(movieDetail);
            await _repositoryManager.SaveAsync();
        }
    }


}
