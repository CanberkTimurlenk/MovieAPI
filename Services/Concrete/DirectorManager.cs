using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Director;
using Repositories.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class DirectorManager : IDirectorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DirectorManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateDirectorInformationAsync(int personId, DirectorRequestForInsertion directorRequestForInsertion)
        {


            var person = await _repositoryManager.Person.Any<Person>(personId);

            if (!person)
                return false;

            var directorInfoToAdd = _mapper.Map<Director>(directorRequestForInsertion);
            directorInfoToAdd.PersonId = personId;

            await _repositoryManager.Director.CreateAsync(directorInfoToAdd);
            await _repositoryManager.SaveAsync();

            return true;

        }

        public async Task DeleteDirectorInformationAsync(int personId)
        {
            var directorInfo = await _repositoryManager.Director.FindAsync(personId);
            _repositoryManager.Director.Remove(directorInfo);

            await _repositoryManager.SaveAsync();

        }

        public async Task<Director> FindByIdAsync(int personId)

            => await _repositoryManager.Director.FindAsync(personId);

        public async Task<(DirectorRequestForUpdate directorRequestForUpdate, Director director)> GetDirectorForPatchAsync(int personId)
        {
            var director = await _repositoryManager.Director.FindAsync(personId);

            if (director is null)
                return (null, null);

            var directorRequestForUpdate = _mapper.Map<DirectorRequestForUpdate>(director);
            return (directorRequestForUpdate, director);
        }

        public async Task SaveChangesForPatchAsync(DirectorRequestForUpdate directorRequestForUpdate, Director director)
        {
            _mapper.Map(directorRequestForUpdate, director);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int personId, DirectorRequestForUpdate directorRequestForUpdate)
        {
            var director = await _repositoryManager.Director.FindAsync(personId);

            if (director is null)
                throw new Exception();

            director = _mapper.Map<Director>(directorRequestForUpdate);

            _repositoryManager.Director.Update(director);
            await _repositoryManager.SaveAsync();
        }
    }
}
