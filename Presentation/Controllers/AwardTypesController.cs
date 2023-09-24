using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.Genre;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.AwardType;
using Models.Concrete.RequestModels.Update.Genre;
using Services.Abstract;
using Services.Concrete;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwardTypesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AwardTypesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("get/{award_type_id:int}")]
        public IActionResult FindByIdAsync([FromRoute(Name = "award_type_id")] int awardTypeId)
        {
            _serviceManager.AwardTypeService.FindByIdAsync(awardTypeId);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{award_type_id:int}")]
        public IActionResult DeleteByIdAsync([FromRoute(Name = "award_type_id")] int awardTypeId)
        {
            _serviceManager.AwardTypeService.DeleteByIdAsync(awardTypeId);
            return StatusCode(204);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] AwardTypeRequestForInsertion awardType)
        {
            _serviceManager.AwardTypeService.CreateAsync(awardType);
            return StatusCode(201);
        }

        [HttpPatch]
        [Route("update/{award_type_id:int}")]
        public async Task<IActionResult> PartiallyUpdateAsync([FromRoute(Name = "award_type_id")] int awardTypeId, [FromBody] JsonPatchDocument<AwardTypeRequestForUpdate> awardType)
        {
            var patchData = await _serviceManager.AwardTypeService.GetAwardTypeForPatch(awardTypeId);

            awardType.ApplyTo(patchData.awardTypeRequestForUpdate);

            await _serviceManager.AwardTypeService.SaveChangesForPatchAsync(patchData.awardTypeRequestForUpdate, patchData.awardType);

            return StatusCode(204);
        }

        [HttpPut]
        [Route("update/{award_type_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "award_type_id")] int awardTypeId, AwardTypeRequestForUpdate awardTypeRequestForUpdate)
        {

            await _serviceManager.AwardTypeService.UpdateAsync(awardTypeId, awardTypeRequestForUpdate);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetAwardTypeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }

    }
}
