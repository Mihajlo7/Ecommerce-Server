using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Products.Service;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts([Required] int page)
        {
            return  Ok(await _productService.GetAllProducts(page));
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetProductById([Required] Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }
    }
}
