using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ActorManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<bool> AddActorInformationAsync(int personId, ActorRequestForInsertion actorRequestForInsertion)
        {
            var person = await _repositoryManager.Person.Any<Person>(personId);

            if (!person)
                return false;

            var actorInfoToAdd = _mapper.Map<Actor>(actorRequestForInsertion);
            actorInfoToAdd.PersonId = personId;

            await _repositoryManager.Actor.CreateAsync(actorInfoToAdd);
            await _repositoryManager.SaveAsync();

            return true;

        }


        public async Task DeleteActorInformationAsync(int personId)
        {

            var actorInfo = await _repositoryManager.Actor.FindAsync(personId);
            _repositoryManager.Actor.Remove(actorInfo);

            await _repositoryManager.SaveAsync();
        }

        public async Task<Actor> FindByIdAsync(int personId)

            => await _repositoryManager.Actor.FindAsync(personId);

        public async Task<(ActorRequestForUpdate actorRequestForUpdate, Actor actor)> GetActorForPatchAsync(int personId)
        {
            var actor = await _repositoryManager.Actor.FindAsync(personId);

            if (actor is null)
                return (null, null);

            var actorRequestForUpdate = _mapper.Map<ActorRequestForUpdate>(actor);
            return (actorRequestForUpdate, actor);
        }

        public async Task SaveChangesForPatchAsync(ActorRequestForUpdate actorRequestForUpdate, Actor actor)
        {
            _mapper.Map(actorRequestForUpdate, actor);
            await _repositoryManager.SaveAsync();

        }

        public async Task UpdateAsync(int personId, ActorRequestForUpdate actorRequestForUpdate)
        {
            var actor = await _repositoryManager.Actor.FindAsync(personId);

            if (actor is null)
                throw new Exception();

            actor = _mapper.Map<Actor>(actorRequestForUpdate);

            _repositoryManager.Actor.Update(actor);
            await _repositoryManager.SaveAsync();
        }
    }
}



