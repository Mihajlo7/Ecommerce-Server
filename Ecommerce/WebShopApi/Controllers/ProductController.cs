using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Mediator.GetAllProducts;
using Products.Mediator.GetAppleProducts;
using Products.Mediator.GetProductById;
using Products.Mediator.GetProductsByCategory;
using Products.Mediator.GetProductsBySubCategory;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts([Required] int page)
        {
            return  Ok(await _mediator.Send(new GetAllProductsQuery(page)));
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetProductById([Required] Guid id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpGet("apple")]
        public async Task<IActionResult> GetAppleProducts()
        {
            return Ok(await _mediator.Send(new GetAppleProductsQuery()));
        }
        [HttpGet("getByCategory")]
        public async Task<IActionResult> GetProductsByCategory([Required] Guid categoryId, [Required] int page)
        {
            return Ok(await _mediator.Send(new GetProductsByCategoryQuery(categoryId, page)));
        }
        [HttpGet("getBySubCategory")]
        public async Task<IActionResult> GetProductsBySubCategory([Required] Guid subCategoryId)
        {
            return Ok(await _mediator.Send(new GetProductsBySubCategoryIdQuery(subCategoryId)));
        }
    }
}
