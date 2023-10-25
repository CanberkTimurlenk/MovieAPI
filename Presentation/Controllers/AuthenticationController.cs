using Microsoft.AspNetCore.Mvc;
using Models.Concrete.RequestModels.Insertion.User;
using Models.Concrete.RequestModels.Read.User;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterRequest userForRegister)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegister);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationRequest userForAuthentication)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(userForAuthentication))
                return Unauthorized();

            return Ok(new
            {

                Token = await _serviceManager.AuthenticationService.CreateToken(true)
            });


        }

    }
}
