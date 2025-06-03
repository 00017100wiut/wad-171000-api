using _17100.Models;
using _17100.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _17100.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepo _repo;

        public ProductsController(ProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _repo.GetByIDAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _repo.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ID }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var existing = await _repo.GetByIDAsync(product.ID);
            if (existing == null)
                return NotFound();

            await _repo.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIDAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
