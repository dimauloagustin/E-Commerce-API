using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_repository.Find(id));
        }

        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            var res = _repository.Add(category);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult EditCategory(int id, Category category)
        {
            category.Id = id;
            var res = _repository.Update(category);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var res = _repository.Delete(_repository.Find(id));
            return Ok(res);
        }
    }
}
