using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Products.Core.DTOs;
using Products.Infrastructure;

namespace Products.Mediator.GetAppleProducts
{
    internal sealed class GetAppleProducts : IQueryHandler<GetAppleProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAppleProducts(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetAppleProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAppleProducts();
        }
    }
}
