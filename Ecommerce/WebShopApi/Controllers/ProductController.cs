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

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([Required] int page)
        {
            return  Ok(await _productService.GetAllProducts(page));
        }
        
    }
}
