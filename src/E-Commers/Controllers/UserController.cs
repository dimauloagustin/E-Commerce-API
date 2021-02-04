using Application.Features.User.Commands;
using Application.Features.User.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        public UserController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetUserAsync(int id)
        {
            return Ok(await Mediator.Send(new GetUserCommand() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostUserAsync(CreateUserCommand user)
        {
            return Created(await Mediator.Send(user));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> UpdateUserAsync(int id, UpdateUserCommand user)
        {
            return Ok(await Mediator.Send(user.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteUserAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        }
    }
}
