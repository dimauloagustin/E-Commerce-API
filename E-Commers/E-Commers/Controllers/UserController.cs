using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_repository.Find(id));
        }

        [HttpPost]
        public IActionResult PostUser(User user)
        {
            var res = _repository.Add(user);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, User user)
        {
            user.Id = id;
            var res = _repository.Update(user);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var res = _repository.Delete(_repository.Find(id));
            return Ok(res);
        }
    }
}
