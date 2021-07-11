using Application.Commands.Categories;
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
    public class CategoryController : BaseApiController
    {
        public CategoryController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new GetCategory() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostCategoryAsync(CreateCategory category)
        {
            return Created(await Mediator.Send(category));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> EditCategoryAsync(int id, UpdateCategory category)
        {
            return Ok(await Mediator.Send(category.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategory() { Id = id }));
        }
    }
}
