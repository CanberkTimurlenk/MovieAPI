using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.Language;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Langauge;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LanguagesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("{language_id:int}")]
        public IActionResult GetByLanguageByIdAsync([FromRoute(Name = "language_id")] int languageId)
        {
            _serviceManager.LanguageService.FindByIdAsync(languageId);

            return Ok();    //  StatusCode 200
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAsync([FromBody] LanguageRequestForInsertion language)
        {
            _serviceManager.LanguageService.CreateAsync(language);
            return StatusCode(201);     //  Created

            // otherwise
            //return UnprocessableEntity();     //  Unprocessable Entity
        }

        [HttpPatch]
        [Route("{language_id:int}")]
        public async Task<IActionResult> PartiallyUpdateAsync([FromRoute(Name = "language_id")] int languageId, [FromBody] JsonPatchDocument<LanguageRequestForUpdate> language)
        {
            var patchData = await _serviceManager.LanguageService.GetLanguageForPatchAsync(languageId);

            language.ApplyTo(patchData.languageRequestForUpdate);

            await _serviceManager.LanguageService.SaveChangesForPatchAsync(patchData.languageRequestForUpdate, patchData.language);

            return StatusCode(204);
        }

        [HttpDelete]
        [Route("{language_id:int}")]
        public IActionResult Delete([FromRoute(Name = "language_id")] int languageId)
        {
            _serviceManager.LanguageService.DeleteByIdAsync(languageId);
            return NoContent();     //  Created

            // otherwise
            //return UnprocessableEntity();     //  Unprocessable Entity
        }

        [HttpPut]
        [Route("{language_id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "language_id")] int languageId, LanguageRequestForUpdate language)
        {

            await _serviceManager.LanguageService.UpdateAsync(languageId, language);

            return StatusCode(204);     //  No Content
        }

        [HttpOptions]
        [Route("options")]
        public IActionResult GetLanguageOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, DELETE, PATCH, OPTIONS");
            return Ok();
        }



    }
}
