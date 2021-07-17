using Application.Features.Login;
using Application.Features.Login.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class LoginController : BaseApiController
    {
        public LoginController() { }

        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> LogIn(LoginUserService command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
