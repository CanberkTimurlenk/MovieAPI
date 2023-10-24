using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Genre;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Genre;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;


        public GenresController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet]
        [Route("{genre_id:int}")]
        public IActionResult FindByIdAsync([FromRoute(Name = "genre_id")] int genreId)
        {
            _serviceManager.GenreService.FindByIdAsync(genreId);

            return Ok();
        }

        [HttpDelete]
        [Route("{genre_id:int}")]
        public IActionResult DeleteByIdAsync([FromRoute(Name = "genre_id")] int genreId)
        {
            _serviceManager.GenreService.DeleteByIdAsync(genreId);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] GenreRequestForInsertion genre)
        {
            _serviceManager.GenreService.CreateAsync(genre);
            return Ok();
        }

        [HttpPatch]
        [Route("{genre_id:int}")]
        public async Task<IActionResult> PartiallyUpdateAsync([FromRoute(Name = "genre_id")] int genreId, [FromBody] JsonPatchDocument<GenreRequestForUpdate> genre)
        {
            var patchData = await _serviceManager.GenreService.GetGenreForPatchAsync(genreId);

            genre.ApplyTo(patchData.genreRequestForUpdate);

            await _serviceManager.GenreService.SaveChangesForPatchAsync(patchData.genreRequestForUpdate, patchData.genre);

            return StatusCode(204);
        }

        [HttpPut]
        [Route("{genre_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "genre_id")] int genreId, GenreRequestForUpdate genre)
        {

            await _serviceManager.GenreService.UpdateAsync(genreId, genre);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetGenreOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }

    }
}
