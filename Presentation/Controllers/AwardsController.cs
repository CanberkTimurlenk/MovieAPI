using Microsoft.AspNetCore.Mvc;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Award;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Award;
using Services.Abstract;
using Services.Concrete;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AwardsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AwardsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("get/{award_type_id:int}/{movie_id:int}")]
        public IActionResult GetByIdAsync([FromRoute(Name = "award_type_id")] int awardTypeId, [FromRoute(Name = "movie_Id")] int movieId)
        {
            _serviceManager.AwardService.FindByIdAsync(awardTypeId, movieId);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{award_type_id:int}/{movie_id:int}")]
        public IActionResult DeleteByIdAsync([FromRoute(Name = "award_type_id")] int awardTypeId, [FromRoute(Name = "movie_Id")] int movieId)
        {
            _serviceManager.AwardService.DeleteByIdAsync(awardTypeId, movieId);
            return StatusCode(204);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] AwardRequestForInsertion award)
        {
            _serviceManager.AwardService.CreateAsync(award);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("update/{award_type_id:int}/{movie_id:int}")]
        public async Task<IActionResult> UpdateAwardByAwardIdAndMovieIdAsync([FromRoute(Name = "award_id")] int awardId, [FromRoute(Name = "movie_id")] int movieId, AwardRequestForUpdate awardRequestForUpdate)
        {

            await _serviceManager.AwardService.UpdateAsync(awardId, movieId, awardRequestForUpdate);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetAwardOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
