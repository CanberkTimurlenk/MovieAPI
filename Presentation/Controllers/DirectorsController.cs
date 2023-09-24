using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Update.Director;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Concrete.RequestModels.Insertion.Person;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Update.Actor;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DirectorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("add/{person_id:int}")]
        public async Task<IActionResult> AddDirectorInformationAsync([FromRoute(Name = "person_id")] int personId, [FromBody] DirectorRequestForInsertion directorRequestForInsertion)
        {
            await _serviceManager.DirectorService.CreateDirectorInformationAsync(personId, directorRequestForInsertion);

            return StatusCode(204);     //  No Content
        }


        [HttpGet("get/{person_id:int}")]
        public async Task<IActionResult> AddDirectorInformationByPersonIdAsync([FromRoute(Name = "person_id")] int personId, DirectorRequestForInsertion directorRequestForInsertion)
        {
            await _serviceManager.DirectorService.CreateDirectorInformationAsync(personId, directorRequestForInsertion);

            return Ok();     //  Ok
        }

        [HttpDelete("delete/{person_id:int}")]
        public async Task<IActionResult> DeleteDirectorInformationByIdAsync([FromRoute(Name = "person_id")] int personId)
        {
            await _serviceManager.DirectorService.DeleteDirectorInformationAsync(personId);

            return StatusCode(204);     //  No Content
        }

        [HttpPatch("update/{person_id:int}")]
        public async Task<IActionResult> ReplaceDirectorInformationByPersonId([FromRoute] int personId, JsonPatchDocument<DirectorRequestForUpdate> director)
        {
            if (!director.Operations.All(op => op.OperationType == OperationType.Replace))
                return BadRequest();

            var existed = await _serviceManager.DirectorService.GetDirectorForPatchAsync(personId);

            director.ApplyTo(existed.directorRequestForUpdate);

            await _serviceManager.DirectorService.SaveChangesForPatchAsync(existed.directorRequestForUpdate, existed.director);

            return StatusCode(204);     //  No Content
        }

        [HttpPut]
        [Route("update/{person_id:int}")]
        public async Task<IActionResult> UpdateDirectorInformationByPersonIdAsync([FromRoute(Name = "person_id")] int personId, DirectorRequestForUpdate director)
        {

            await _serviceManager.DirectorService.UpdateAsync(personId, director);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetDirectorOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
