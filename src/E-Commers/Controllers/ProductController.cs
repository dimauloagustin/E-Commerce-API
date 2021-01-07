using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_repository.Find(id));
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            var res = _repository.Add(product);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            product.Id = id;
            var res = _repository.Update(product);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var res = _repository.Delete(_repository.Find(id));
            return Ok(res);
        }
    }
}
