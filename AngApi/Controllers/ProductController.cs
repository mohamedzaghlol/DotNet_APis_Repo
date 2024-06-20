using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;

namespace AngApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _globalService;

        public ProductController(ProductService globalService)
        {
            _globalService = globalService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _globalService.getAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _globalService.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var result = _globalService.addProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var res = _globalService.updateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id != null)
            {
                return NotFound();
            }
            _globalService.removeProduct(id);
            return NoContent();
        }
    }
}
