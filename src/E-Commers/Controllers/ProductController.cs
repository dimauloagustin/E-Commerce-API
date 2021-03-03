using Application.Features.Product.Commands;
using Application.Features.Product.Querries;
using Application.Features.Product.Responses;
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
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetProductAsync(int id)
        {
            return Ok(await Mediator.Send(new GetProductCommand() { Id = id }));
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> GetProductsAsync([FromQuery] GetProductsQuerry getProductsQuerry)
        {
            return Ok(await Mediator.Send(getProductsQuerry));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateProductCommand product)
        {
            return Created(await Mediator.Send(product));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> EditProductAsync(int id, UpdateProductCommand product)
        {
            return Ok(await Mediator.Send(product.Id = id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteProductAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand() { Id = id }));
        }

        [HttpPost("image")]
        public IActionResult Upload(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            // If file with same name exists delete it
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            // Create new local file and copy contents of uploaded file
            using (var localFile = System.IO.File.OpenWrite(fileName))
            using (var uploadedFile = file.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            return Ok();
        }
    }
}
