using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Genre;
using Models.Concrete.RequestModels.Update.Genre;

namespace Services.Abstract
{
    public interface IGenreService
    {        
        Task<int> CreateAsync(GenreRequestForInsertion genreRequestForInsertion);
        Task<bool> DeleteByIdAsync(int id);
        Task<Genre> FindByIdAsync(int id);
        Task<(GenreRequestForUpdate genreRequestForUpdate, Genre genre)> GetGenreForPatchAsync(int id);
        Task SaveChangesForPatchAsync(GenreRequestForUpdate genreRequestForUpdate, Genre genre);
        Task UpdateAsync(int genreId, GenreRequestForUpdate genreRequestForUpdate);
    }
}