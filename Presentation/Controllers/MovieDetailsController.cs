using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;
using Models.Concrete.RequestModels.Update.MovieDetailRequestForUpdate;
using Models.Concrete.RequestModels.Update.Actor;
using Services.Abstract;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieDetailsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MovieDetailsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("{movie_id:int}")]
        public IActionResult GetByIdAsync([FromRoute(Name = "movie_id")] int movieId)
        {
            _serviceManager.MovieDetailService.FindByIdAsync(movieId);
            return Ok();
        }

        [HttpDelete]
        [Route("{movie_id:int}")]
        public IActionResult DeleteByIdAsync([FromRoute(Name = "movie_id")] int movieId)
        {
            _serviceManager.MovieDetailService.DeleteByIdAsync(movieId);
            return StatusCode(204);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] MovieDetailRequestForInsertion movieDetail)
        {
            _serviceManager.MovieDetailService.CreateAsync(movieDetail);
            return StatusCode(201);
        }

        [HttpPatch("{movie_id:int}")]
        public async Task<IActionResult> ReplaceMovieDetailByMovieId([FromRoute(Name = "movie_id")] int movieId, JsonPatchDocument<MovieDetailRequestForUpdate> movieDetail)
        {
            if (!movieDetail.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var existed = await _serviceManager.MovieDetailService.GetMovieDetailForPatchAsync(movieId);

            movieDetail.ApplyTo(existed.movieDetailRequestForUpdate);

            await _serviceManager.MovieDetailService.SaveChangesForPatchAsync(existed.movieDetailRequestForUpdate, existed.movieDetail);

            return StatusCode(204);     //  No Content
        }

        [HttpPut]
        [Route("{person_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "movie_id")] int movieId, MovieDetailRequestForUpdate movieDetail)
        {

            await _serviceManager.MovieDetailService.UpdateAsync(movieId, movieDetail);

            return StatusCode(204);     //  No Content
        }


        [HttpOptions]
        [Route("options")]
        public IActionResult GetMovieDetailOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }

    }
}

