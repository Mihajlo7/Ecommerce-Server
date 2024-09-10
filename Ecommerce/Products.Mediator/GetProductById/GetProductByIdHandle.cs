using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Products.Core.DTOs;
using Products.Infrastructure;
using System.Text.Json;

namespace Products.Mediator.GetProductById
{
    public class GetProductByIdHandle : IQueryHandler<GetProductByIdQuery, ProductFullDTO>
    {
        private readonly IDbOperations<ProductDbContext> _dbOperations;

        public GetProductByIdHandle(IDbOperations<ProductDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<ProductFullDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductId",System.Data.SqlDbType.UniqueIdentifier){Value=request.productId}
                };

                var rawProductWithFullData = await _dbOperations.GetAsync<ProductFullRawDTO>(ProductsOperations.GET_PRODUCT_BY_ID,parameters);

                var mappedProductWithFullData= MapToProductFullDTO(rawProductWithFullData);
                return mappedProductWithFullData;

            }catch (Exception ex)
            {
                return null;
            }
        }

        private ProductFullDTO MapToProductFullDTO(ProductFullRawDTO rawDTO)
        {
            return new ProductFullDTO
            {
                Id = rawDTO.Id,
                ProductNumber = rawDTO.ProductNumber,
                Name = rawDTO.Name,
                Price = rawDTO.Price,
                Color = rawDTO.Color,
                Class = rawDTO.Class,
                Size = JsonSerializer.Deserialize<SizeDTO>(rawDTO.Size), // Parsiranje JSON stringa u objekat SizeDTO
                Weight = JsonSerializer.Deserialize<WeightDTO>(rawDTO.Weight),

                SubCategory = new SubCategoryDTO
                {
                    SubCategoryId = rawDTO.SubCategoryId,
                    SubCategoryNumber = rawDTO.SubCategoryNumber,
                    SubCategoryName = rawDTO.SubCategoryName
                }
            };
        }
    }
}
