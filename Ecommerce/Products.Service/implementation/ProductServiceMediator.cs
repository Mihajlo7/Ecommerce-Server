using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Products.Core.DTOs;
using Products.Mediator.GetAllProducts;
using Products.Mediator.GetProductById;

namespace Products.Service.implementation
{
    public class ProductServiceMediator : IProductService
    {
        private readonly IMediator _mediator;

        public ProductServiceMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProducts(int page = 1)
        {
            return await _mediator.Send(new GetAllProductsQuery(page));
        }

        public Task<IEnumerable<ProductDTO>> GetAppleProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductFullDTO> GetProductById(Guid id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public Task<IEnumerable<ProductDTO>> GetProductsByCategory(Guid categoryId, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProductsBySubCategory(Guid subCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetSamsungProducts()
        {
            throw new NotImplementedException();
        }
    }
}
