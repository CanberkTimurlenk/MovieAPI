using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Director;

namespace Services.Abstract
{
    public interface IDirectorService
    {
        Task<bool> CreateDirectorInformationAsync(int personId, DirectorRequestForInsertion directorRequestForInsertion);
        Task DeleteDirectorInformationAsync(int personId);
        Task<Director> FindByIdAsync(int personId);        
        Task<(DirectorRequestForUpdate directorRequestForUpdate, Director director)> GetDirectorForPatchAsync(int personId);
        Task SaveChangesForPatchAsync(DirectorRequestForUpdate directorRequestForUpdate, Director director);
        Task UpdateAsync(int personId, DirectorRequestForUpdate directorRequestForUpdate);
    }
}