using Application.Features.Product;
using Application.Features.Product.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateProduct product)
        {
            return Created(await Mediator.Send(product));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> EditProductAsync(int id, UpdateProduct product)
        {
            return Ok(await Mediator.Send(product.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
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
