using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Products.Core.DTOs;
using Products.Infrastructure;

namespace Products.Mediator.GetProductsByCategory
{
    internal sealed class GetProductsByCategoryHandler : IQueryHandler<GetProductsByCategoryQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            int offset = (request.page - 1) * ProductPageInf.NEXT_PRODUCTS;
            int next = ProductPageInf.NEXT_PRODUCTS;

            return await _productRepository.GetAllProductsByCategory(request.CategoryId,offset,next);
        }
    }
}
