using Application.Features.Product;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetProductAsync(int id)
        {
            return Ok(await Mediator.Send(new GetProduct() { Id = id }));
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> GetProductsAsync([FromQuery] GetProducts getProducts)
        {
            return Ok(await Mediator.Send(getProducts));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateProduct createProduct)
        {
            return Created(await Mediator.Send(createProduct));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> EditProductAsync(int id, UpdateProduct updateProduct)
        {
            updateProduct.Id = id;
            return Ok(await Mediator.Send(updateProduct));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteProductAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteProduct() { Id = id }));
        }

        [HttpPost("image")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> UploadProductImageAsync(IFormFile image)
        {
            return Ok(await Mediator.Send(new UploadProductPhoto() { File = image }));
        }
    }
}
