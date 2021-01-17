﻿using Application.Features.User.Commands;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetUserAsync(int id)
        {
            return Ok(await Mediator.Send(new GetUserCommand() { Id = id }));
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> PostUserAsync(CreateUserCommand user)
        {
            return Ok(await Mediator.Send(user));
        }

        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateUser(int id, UpdateUserCommand user)
        {
            return Ok(await Mediator.Send(user.Id = id));
        }

        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        }
    }
}
