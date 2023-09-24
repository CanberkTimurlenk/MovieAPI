using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Genre;
using Models.Concrete.RequestModels.Update.Genre;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GenreManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(GenreRequestForInsertion genreRequestForInsertion)
        {

            var genreToCreate = _mapper.Map<Genre>(genreRequestForInsertion);

            await _repositoryManager.Genre.CreateAsync(genreToCreate);

            await _repositoryManager.SaveAsync();

            return (genreToCreate.Id);

        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var movie = await _repositoryManager.Genre.FindAsync(id);

            var result = _repositoryManager.Genre.Remove(movie);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<(GenreRequestForUpdate genreRequestForUpdate, Genre genre)> GetGenreForPatchAsync(int id)
        {
            var genreToUpdate = await _repositoryManager.Genre.FindAsync(id);

            var genreRequestForUpdate = _mapper.Map<GenreRequestForUpdate>(genreToUpdate);

            return (genreRequestForUpdate, genreToUpdate);

        }
            
        public async Task SaveChangesForPatchAsync(GenreRequestForUpdate genreRequestForUpdate, Genre genre)
        {
            _mapper.Map(genreRequestForUpdate, genre);
            await _repositoryManager.SaveAsync();
        }

        public async Task<Genre> FindByIdAsync(int id)

          => await _repositoryManager.Genre.FindAsync(id);

        public async Task UpdateAsync(int genreId, GenreRequestForUpdate genreRequestForUpdate)
        {
            var genre = await _repositoryManager.Genre.FindAsync(genreId);

            if (genre is null)
                throw new Exception();

            genre = _mapper.Map<Genre>(genreRequestForUpdate);

            _repositoryManager.Genre.Update(genre);
            await _repositoryManager.SaveAsync();
        }
    }
}
