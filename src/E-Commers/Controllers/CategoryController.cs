using Application.Features.Category.Commands;
using Application.Features.Category.Responses;
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
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryCommand() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostCategoryAsync(CreateCategoryCommand category)
        {
            return Created(await Mediator.Send(category));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> EditCategoryAsync(int id, UpdateCategoryCommand category)
        {
            return Ok(await Mediator.Send(category.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteCategoryAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand() { Id = id }));
        }
    }
}
