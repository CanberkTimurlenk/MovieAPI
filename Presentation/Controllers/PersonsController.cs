using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.RequestModels.Update.Person;
using Models.Concrete.RequestModels.Update.Actor;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("{person_id:int}")]
        public IActionResult FindByIdAsync([FromRoute(Name = "person_id")] int personId)
        {
            _serviceManager.PersonService.FindByIdAsync(personId);
            return Ok();
        }

        [HttpDelete]
        [Route("{person_id:int}")]
        public IActionResult DeleteByIdAsync([FromRoute(Name = "person_id")] int personId)
        {
            _serviceManager.PersonService.DeleteByIdAsync(personId);
            return StatusCode(204);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] PersonRequestForInsertion person)
        {
            _serviceManager.PersonService.CreateAsync(person);
            return StatusCode(201);
        }

        [HttpPatch("{person_id:int}/genres/{genre_id:int}")]
        public async Task<IActionResult> ReplacePersonGenreAsync([FromRoute(Name = "person_id")] int personId, [FromRoute(Name = "genre_id")] int genreId, [FromBody] JsonPatchDocument<PersonGenreRequestForUpdate> personPatch)
        {
            if (!personPatch.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var personGenre = await _serviceManager.PersonService.GetGenreIdsForPatch(personId);

            if (!personGenre.Genre.Any(g => g.Equals(genreId)))
                return NotFound();

            var genreIdToUpdate = new List<int> { genreId };
            var personGenreToUpdate = new PersonGenreRequestForUpdate { Genre = genreIdToUpdate };

            personPatch.ApplyTo(personGenreToUpdate);

            await _serviceManager.PersonService.PartiallyUpdatePersonGenresAsync(personId, genreId, personGenreToUpdate.Genre);

            return StatusCode(204);     //  No Content
        }

        [HttpPost("{person_id:int}/genres")]
        public async Task<IActionResult> AddPersonGenreAsync([FromRoute(Name = "person_id")] int personId, [FromBody] IEnumerable<int> genreIdsToAdd)
        {
            await _serviceManager.PersonService.AddRangePersonGenresAsync(personId, genreIdsToAdd);

            return StatusCode(204);     //  No Content
        }

        [HttpDelete("{person_id:int}/genres")]
        public async Task<IActionResult> PartiallyDeletePersonGenreAsync([FromRoute(Name = "person_id")] int personId, [FromBody] IEnumerable<int> genreIdsToDelete)
        {
            await _serviceManager.PersonService.DeleteRangePersonGenresAsync(personId, genreIdsToDelete);

            return StatusCode(204);     //  No Content
        }

        [HttpPut]
        [Route("{person_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "person_id")] int personId, PersonRequestForUpdate person)
        {

            await _serviceManager.PersonService.UpdateAsync(personId, person);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetPersonOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
