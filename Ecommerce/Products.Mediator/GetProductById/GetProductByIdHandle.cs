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
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductFullDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var foundProductById = await _productRepository.GetProductById(request.productId);
            return foundProductById;
        }

        
    }
}
