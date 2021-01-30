﻿using Application.Features.Product.Commands;
using Application.Features.Product.Querries;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController() { }

        [HttpGet("{id}")]
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
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateProductCommand product)
        {
            return Ok(await Mediator.Send(product));
        }

        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> EditProductAsync(int id, UpdateProductCommand product)
        {
            return Ok(await Mediator.Send(product.Id = id));
        }

        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteProductAsync(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand() { Id = id }));
        }
    }
}
