using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.Location;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Location;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LocationsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("get/{location_id:int}")]
        public IActionResult GetByLocationByIdAsync([FromRoute(Name = "location_id")] int locationId)
        {
            _serviceManager.LocationService.FindByIdAsync(locationId);

            return Ok();    //  StatusCode 200
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] LocationRequestForInsertion location)
        {

            _serviceManager.LocationService.CreateAsync(location);
            return StatusCode(201);     //  Created

        }

        [HttpDelete]
        [Route("delete/{location_id:int}")]
        public IActionResult Delete([FromRoute(Name = "location_id")] int locationId)
        {
            _serviceManager.LocationService.DeleteByIdAsync(locationId);
            return NoContent();     //  Created

            // otherwise
            //return UnprocessableEntity();     //  Unprocessable Entity
        }

        [HttpPatch]
        [Route("update/{location_id:int}")]
        public async Task<IActionResult> PartiallyUpdateAsync([FromRoute(Name = "location_id")] int locationId, [FromBody] JsonPatchDocument<LocationRequestForUpdate> location)
        {
            var patchData = await _serviceManager.LocationService.GetLocationForPatchAsync(locationId);

            location.ApplyTo(patchData.locationRequestForUpdate);

            await _serviceManager.LocationService.SaveChangesForPatchAsync(patchData.locationRequestForUpdate, patchData.location);

            return StatusCode(204);
        }

        [HttpPut]
        [Route("update/{location_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "location_id")] int locationId, LocationRequestForUpdate location)
        {

            await _serviceManager.LocationService.UpdateAsync(locationId, location);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetLocationOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
