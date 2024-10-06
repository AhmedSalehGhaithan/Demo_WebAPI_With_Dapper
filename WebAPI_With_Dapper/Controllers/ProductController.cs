using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_With_Dapper.Implementation;
using WebAPI_With_Dapper.Interfaces;
using WebAPI_With_Dapper.Models;

namespace WebAPI_With_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct _productRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            int result = await _productRepo.AddProductAsync(product);
            if (result == 0)
                return BadRequest();
            else
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            int result = await _productRepo.UpdateProductAsync(product);
            return result > 0 ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _productRepo.DeleteProductAsync(id);
            return result > 0 ? NoContent() : BadRequest();
        }
    }
}
