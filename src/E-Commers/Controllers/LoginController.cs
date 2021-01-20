using Application.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseApiController
    {
        public LoginController() { }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> LogIn(LoginUserService command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
