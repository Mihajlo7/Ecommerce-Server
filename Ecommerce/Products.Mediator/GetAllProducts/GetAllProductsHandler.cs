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
        private readonly IDbOperations<ProductDbContext> _dbOperations;

        public GetAllProductsHandler(IDbOperations<ProductDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int offset = (request.page - 1)*ProductPageInf.NEXT_PRODUCTS;
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Offset",offset),
                    new SqlParameter("@Next",ProductPageInf.NEXT_PRODUCTS)
                };
                var allProdycts = await _dbOperations.GetAllAsync<ProductDTO>(ProductsOperations.GET_ALL_PRODUCTS, parameters);

                return allProdycts;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
