using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Person;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(PersonRequestForInsertion person)
        {

            var personToCreate = _mapper.Map<Person>(person);

            await _repositoryManager.Person.CreateAsync(personToCreate);
            await _repositoryManager.SaveAsync();

            return personToCreate.Id;

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var person = await _repositoryManager.Person.FindAsync(id);

            var result = _repositoryManager.Person.Remove(person);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<Person> FindByIdAsync(int id)

          => await _repositoryManager.Person.FindAsync(id);

        public async Task PartiallyUpdatePersonGenresAsync(int personId, int genreIdToReplace, IEnumerable<int> genreIdsToUpdate)
        {

            var movieToUpdate = await _repositoryManager.Person.FindAsync(personId);

            _repositoryManager.Person.RemovePersonGenre(personId, genreIdToReplace);

            await _repositoryManager.Person.AddRangePersonGenresAsync(personId, genreIdsToUpdate);

            await _repositoryManager.SaveAsync();

        }

        public async Task AddRangePersonGenresAsync(int personId, IEnumerable<int> genreIdsToAdd)
        {
            await _repositoryManager.Person.AddRangePersonGenresAsync(personId, genreIdsToAdd);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteRangePersonGenresAsync(int personId, IEnumerable<int> genreIdsToDelete)
        {
            _repositoryManager.Person.RemoveRangePersonGenres(personId, genreIdsToDelete);

            await _repositoryManager.SaveAsync();
        }

        public async Task<PersonGenreRequestForUpdate> GetGenreIdsForPatch(int id)
        {
            var genres = await _repositoryManager.Person.GetGenreIds(id);
            return new PersonGenreRequestForUpdate { Genre = genres };
        }

        public async Task UpdateAsync(int personId, PersonRequestForUpdate personRequestForUpdate)
        {
            var person = await _repositoryManager.Person.FindAsync(personId);

            if (person is null)
                throw new Exception();

            person = _mapper.Map<Person>(personRequestForUpdate);

            _repositoryManager.Person.Update(person);
            await _repositoryManager.SaveAsync();
        }
    }


}
