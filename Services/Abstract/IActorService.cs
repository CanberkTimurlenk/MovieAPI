using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;

namespace Services.Abstract
{
    public interface IActorService
    {
        Task<bool> AddActorInformationAsync(int personId, ActorRequestForInsertion actorRequestForInsertion);
        Task DeleteActorInformationAsync(int personId);
        Task<Actor> FindByIdAsync(int personId);
        Task<(ActorRequestForUpdate actorRequestForUpdate, Actor actor)> GetActorForPatchAsync(int personId);
        Task SaveChangesForPatchAsync(ActorRequestForUpdate actorRequestForUpdate, Actor actor);
        Task UpdateAsync(int personId, ActorRequestForUpdate actorRequestForUpdate);
    }
}