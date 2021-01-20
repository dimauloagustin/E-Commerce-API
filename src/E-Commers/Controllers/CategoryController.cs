using Application.Features.Category.Commands;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseApiController
    {
        public CategoryController() { }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryCommand() { Id = id }));
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> PostCategoryAsync(CreateCategoryCommand category)
        {
            return Ok(await Mediator.Send(category));
        }

        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> EditCategoryAsync(int id, UpdateCategoryCommand category)
        {
            return Ok(await Mediator.Send(category.Id = id));
        }

        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand() { Id = id }));
        }
    }
}
