using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestFeatures;
using System.Text.Json;
using Models.Concrete.ResponseModels.Movie;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Models.Concrete.RequestModels.Update.Movie;
using Models.Concrete.RequestModels.Insertion.Movie;
using Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MoviesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;

        }

        [HttpGet("get-by-title")]
        public async Task<IActionResult> GetMoviesByTitleAsync(string title, [FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByTitleAsync(title, requestParamaters);

            return CreatePaginatedResponse(result);
        }

        [HttpGet("upcoming-in-30-days")]
        public async Task<IActionResult> GetUpcomingMoviesIn30Days([FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetUpcomingMoviesIn30Days(requestParamaters);

            return Ok(result);

        }

        [Authorize(Roles = "User")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMoviesAsync([FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetAllMoviesAsync(requestParamaters);

            return CreatePaginatedResponse(result);
        }


        [HttpGet("release-status")]
        public async Task<IActionResult> GetMoviesByReleaseStatusAsync(bool isReleased, [FromQuery] MovieParameters requestParameters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByReleaseStatusAsync(isReleased, requestParameters);

            return CreatePaginatedResponse(result);
        }

        [HttpGet("genre/{genre_id:int}")]
        public async Task<IActionResult> GetMoviesByGenreIdAsync([FromRoute(Name = "genre_id")] int genreId, [FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByGenreIdAsync(genreId, requestParamaters);

            return CreatePaginatedResponse(result);
        }

        [HttpGet("{movie_id:int}")]
        public async Task<IActionResult> FindByIdAsync([FromRoute(Name = "movie_id")] int movieId)
        {
            var movie = await _serviceManager.MovieService.FindByIdAsync(movieId);

            return movie is null ? NotFound() : Ok(movie);

        }

        [HttpGet("duration-range")]
        public async Task<IActionResult> GetMoviesByDurationIntervalAsync(int minDuration, int maxDuration, [FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByDurationIntervalAsync(minDuration, maxDuration, requestParamaters);

            return CreatePaginatedResponse(result);


        }

        [HttpGet("with-details/{movie_id:int}")]
        public async Task<IActionResult> GetMovieWithDetailsByMovieId([FromRoute(Name = "movie_id")] int movieId)
        {
            var movie = await _serviceManager.MovieService.GetMovieWithDetailsByMovieId(movieId);

            return movie is null ? NotFound() : Ok(movie);

        }

        [HttpGet("person/{person_id:int}")]
        public async Task<IActionResult> GetMoviesByPersonIdAsync([FromRoute(Name = "person_id")] int personId, [FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByPersonId(personId, requestParamaters);

            return CreatePaginatedResponse(result);

        }

        [HttpGet("location/location-name")]
        public async Task<IActionResult> GetMoviesByLocationNameAsync([FromQuery] string locationName, [FromQuery] MovieParameters requestParamaters)
        {
            var result = await _serviceManager.MovieService.GetMoviesByLocationNameAsync(locationName, requestParamaters);

            return CreatePaginatedResponse(result);

        }




        [HttpDelete("{movie_id:int}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int movieId)
        {
            await _serviceManager.MovieService.DeleteByIdAsync(movieId);

            return StatusCode(204);     //  No Content

        }

        [HttpDelete("{movie_id:int}/genres")]
        public async Task<IActionResult> PartiallyDeleteMovieGenreAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> genreIdsToDelete)
        {
            await _serviceManager.MovieService.DeleteRangeMovieGenresAsync(movieId, genreIdsToDelete);

            return StatusCode(204);     //  No Content
        }

        [HttpDelete("{movie_id:int}/persons")]
        public async Task<IActionResult> PartiallyDeleteMoviePersonAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> personIdsToDelete)
        {
            await _serviceManager.MovieService.DeleteRangeMoviePersonsAsync(movieId, personIdsToDelete);

            return StatusCode(204);     //  No Content
        }

        [HttpDelete("{movie_id:int}/languages")]
        public async Task<IActionResult> PartiallyDeleteMovieLanguageAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> languageIdsToDelete)
        {
            await _serviceManager.MovieService.DeleteRangeMovieLanguagesAsync(movieId, languageIdsToDelete);

            return StatusCode(204);     //  No Content
        }

        [HttpDelete("unreleased")]
        public async Task<IActionResult> DeleteUnreleasedMoviesAsync()
        {
            var deletedCount = await _serviceManager.MovieService.ExecuteDeleteUnreleased();

            return Ok(deletedCount);

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(MovieRequestForInsertion movie)
        {
            await _serviceManager.MovieService.CreateAsync(movie);

            return StatusCode(201);     //  Created

        }

        [HttpPost("{movie_id:int}/genres")]
        public async Task<IActionResult> AddMovieGenreAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> genreIdsToAdd)
        {
            await _serviceManager.MovieService.AddRangeMovieGenresAsync(movieId, genreIdsToAdd);

            return StatusCode(204);     //  No Content
        }

        [HttpPost("{movie_id:int}/persons")]
        public async Task<IActionResult> AddMoviePersonAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> personIdsToAdd)
        {
            await _serviceManager.MovieService.AddRangeMoviePersonsAsync(movieId, personIdsToAdd);

            return StatusCode(204);     //  No Content
        }

        [HttpPost("{movie_id:int}/languages")]
        public async Task<IActionResult> AddMovieLanguageAsync([FromRoute(Name = "movie_id")] int movieId, [FromBody] IEnumerable<int> languageIdsToAdd)
        {
            await _serviceManager.MovieService.AddRangeMovieLanguagesAsync(movieId, languageIdsToAdd);

            return StatusCode(204);     //  No Content
        }

        [HttpPatch("{movie_id:int}/genres/{genre_id:int}")]
        public async Task<IActionResult> ReplaceMovieGenreAsync([FromRoute(Name = "movie_id")] int movieId, [FromRoute(Name = "genre_id")] int genreId, [FromBody] JsonPatchDocument<MovieGenreRequestForUpdate> moviePatch)
        {
            if (!moviePatch.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var movieGenre = await _serviceManager.MovieService.GetGenreIdsForPatch(movieId);

            if (!movieGenre.Genre.Any(g => g.Equals(genreId)))
                return NotFound();

            var genreIdToUpdate = new List<int> { genreId };
            var movieGenreToUpdate = new MovieGenreRequestForUpdate { Genre = genreIdToUpdate };

            moviePatch.ApplyTo(movieGenreToUpdate);

            await _serviceManager.MovieService.PartiallyUpdateMovieGenresAsync(movieId, genreId, movieGenreToUpdate.Genre);

            return StatusCode(204);     //  No Content
        }

        [HttpPatch("{movie_id:int}/persons/{person_id:int}")]
        public async Task<IActionResult> ReplaceMoviePersonAsync([FromRoute(Name = "movie_id")] int movieId, [FromRoute(Name = "person_id")] int personId, [FromBody] JsonPatchDocument<MoviePersonRequestForUpdate> moviePatch)
        {
            if (!moviePatch.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var moviePerson = await _serviceManager.MovieService.GetPersonIdsForPatch(movieId);

            if (!moviePerson.Person.Any(g => g.Equals(personId)))
                return NotFound();

            var personIdToUpdate = new List<int> { personId };
            var moviePersonToUpdate = new MoviePersonRequestForUpdate { Person = personIdToUpdate };

            moviePatch.ApplyTo(moviePersonToUpdate);

            await _serviceManager.MovieService.PartiallyUpdateMovieGenresAsync(movieId, personId, moviePersonToUpdate.Person);

            return StatusCode(204);     //  No Content
        }

        [HttpPatch("{movie_id:int}/languages/{language_id:int}")]
        public async Task<IActionResult> ReplaceMovieLanguageAsync([FromRoute(Name = "movie_id")] int movieId, [FromRoute(Name = "language_id")] int languageId, [FromBody] JsonPatchDocument<MovieLanguageRequestForUpdate> moviePatch)
        {
            if (!moviePatch.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var movieLanguage = await _serviceManager.MovieService.GetLanguageIdsForPatch(movieId);

            if (!movieLanguage.Language.Any(g => g.Equals(languageId)))
                return NotFound();

            var languageIdToUpdate = new List<int> { languageId };
            var movieLanguageToUpdate = new MovieLanguageRequestForUpdate { Language = languageIdToUpdate };

            moviePatch.ApplyTo(movieLanguageToUpdate);

            await _serviceManager.MovieService.PartiallyUpdateMovieGenresAsync(movieId, languageId, movieLanguageToUpdate.Language);

            return StatusCode(204);     //  No Content
        }

        private IActionResult CreatePaginatedResponse((IEnumerable<MovieResponse> movies, MetaData metaData) result)
        {
            Response.Headers.Add("X-PAGINATION", JsonSerializer.Serialize(result.metaData));
            return result.movies.Count().Equals(0) ? NotFound() : Ok(result.movies);
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetMovieOptionss()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
