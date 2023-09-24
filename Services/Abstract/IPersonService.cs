using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Person;

namespace Services.Abstract
{
    public interface IPersonService
    {
        Task<int> CreateAsync(PersonRequestForInsertion person);
        Task<bool> DeleteByIdAsync(int id);
        Task<Person> FindByIdAsync(int id);
        Task PartiallyUpdatePersonGenresAsync(int personId, int genreIdToReplace, IEnumerable<int> genreIdsToUpdate);
        Task AddRangePersonGenresAsync(int personId, IEnumerable<int> genreIdsToAdd);
        Task DeleteRangePersonGenresAsync(int personId, IEnumerable<int> genreIdsToDelete);
        Task<PersonGenreRequestForUpdate> GetGenreIdsForPatch(int id);
        Task UpdateAsync(int personId, PersonRequestForUpdate personRequestForUpdate);
    }
}