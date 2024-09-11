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
        private readonly IDbOperations<ProductDbContext> _dbOperations;

        public GetAppleProducts(IDbOperations<ProductDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetAppleProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var foundAppleProducts = await _dbOperations.GetAllAsync<ProductDTO>(ProductsOperations.GET_APPLE_PRODUCTS);
                return foundAppleProducts;

            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
