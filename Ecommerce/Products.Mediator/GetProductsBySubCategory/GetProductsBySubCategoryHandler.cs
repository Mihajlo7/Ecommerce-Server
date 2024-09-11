using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Products.Core.DTOs;
using Products.Infrastructure;

namespace Products.Mediator.GetProductsBySubCategory
{
    internal sealed class GetProductsBySubCategoryHandler : IQueryHandler<GetProductsBySubCategoryIdQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsBySubCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsBySubCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsBySubCategory
                (request.SubCategoryId);
        }
    }
}
