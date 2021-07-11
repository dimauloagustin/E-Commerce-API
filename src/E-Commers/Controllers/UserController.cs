using Application.Commands.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        public UserController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetUserAsync(int id)
        {
            return Ok(await Mediator.Send(new GetUser() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostUserAsync(CreateUser user)
        {
            return Created(await Mediator.Send(user));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> UpdateUserAsync(int id, UpdateUser user)
        {
            return Ok(await Mediator.Send(user.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteUserAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteUser() { Id = id }));
        }
    }
}
