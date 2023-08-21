using Microsoft.AspNetCore.Mvc;

using Models.Concrete.RequestFeatures;
using System.Text.Json;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public MoviesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet(Name = "GetMoviesByTitle")]
        public async Task<IActionResult> GetMoviesByTitleAsync([FromQuery] string title)
        {
            var result = await _serviceManager.MovieService.GetMoviesByTitleAsync(title, new MovieParameters() { PageSize = 1 });

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));

            return Ok(result.movies);

            
        }

    }
}
