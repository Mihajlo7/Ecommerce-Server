using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Products.Core.DTOs;
using Products.Infrastructure;

namespace Products.Mediator.GetAllProducts
{
    public sealed class GetAllProductsHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            int offset = (request.page - 1) * ProductPageInf.NEXT_PRODUCTS;
            int next= ProductPageInf.NEXT_PRODUCTS;
            
            return await _productRepository.GetAllProducts(offset, next);
        }
    }
}
