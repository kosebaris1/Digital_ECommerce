using D_Core_Layer.Services.Abstract;
using D_Infrastructure_Layer.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null");
            }

            var result = await _productService.AddProduct(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null");
            }

            var result = await _productService.UpdateProduct(id, product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.RemoveProduct(id);
            return Ok(result);
        }
    }
}
