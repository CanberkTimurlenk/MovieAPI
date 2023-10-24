using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ActorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet]
        [Route("{person_id:int}")]
        public async Task<IActionResult> GetDirectorInformationByIdPersonIdAsync([FromRoute(Name = "person_id")] int personId)
        {
            await _serviceManager.DirectorService.FindByIdAsync(personId);

            return Ok();     //  No Content
        }

        [HttpPost]
        [Route("{person_id:int}")]
        public async Task<IActionResult> AddActorInformationAsync([FromRoute(Name = "person_id")] int personId, [FromBody] ActorRequestForInsertion actorRequestForInsertion)
        {

            await _serviceManager.ActorService.AddActorInformationAsync(personId, actorRequestForInsertion);

            return StatusCode(204);     //  No Content
        }

        [HttpDelete]
        [Route("{person_id:int}")]
        public async Task<IActionResult> DeleteActorInformationByIdAsync([FromRoute(Name = "person_id")] int personId)
        {
            await _serviceManager.ActorService.DeleteActorInformationAsync(personId);

            return StatusCode(204);     //  No Content
        }

        [HttpPatch]
        [Route("{person_id:int}")]
        public async Task<IActionResult> ReplaceActorInformationByPersonId([FromRoute(Name = "person_id")] int personId, JsonPatchDocument<ActorRequestForUpdate> actor)
        {
            if (!actor.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var existed = await _serviceManager.ActorService.GetActorForPatchAsync(personId);

            actor.ApplyTo(existed.actorRequestForUpdate);

            await _serviceManager.ActorService.SaveChangesForPatchAsync(existed.actorRequestForUpdate, existed.actor);

            return StatusCode(204);     //  No Content
        }


        [HttpPut]
        [Route("{person_id:int}")]
        public async Task<IActionResult> UpdateActorInformationByPersonIdAsync([FromRoute(Name = "person_id")] int personId, ActorRequestForUpdate actor)
        {

            await _serviceManager.ActorService.UpdateAsync(personId, actor);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetActorOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
