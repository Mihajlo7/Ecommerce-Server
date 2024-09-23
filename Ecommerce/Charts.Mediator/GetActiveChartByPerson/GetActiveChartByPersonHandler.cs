using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Charts.Core.DTOs;
using Charts.Core.Mappers;
using Charts.Infrastructure;
using Generic.Mediator;
using Products.Core.DTOs;
using Products.Infrastructure;

namespace Charts.Mediator.GetActiveChartByPerson
{
    internal class GetActiveChartByPersonHandler : IQueryHandler<GetActiveChartByPersonQuery, ChartDTO>
    {
        private readonly IChartRepository _chartRepository;
        private readonly IProductRepository _productRepository;

        public GetActiveChartByPersonHandler(IChartRepository chartRepository,IProductRepository productRepository)
        {
            _chartRepository = chartRepository;
            _productRepository = productRepository;
        }
        public async Task<ChartDTO> Handle(GetActiveChartByPersonQuery request, CancellationToken cancellationToken)
        {
            // read chart with metadata of products
            var chartWithMetaDataProducts = await 
                _chartRepository.GetActiveChart(request.PersonId);

            // desirialize string to collection json objects
            var productsWithIds = 
                JsonSerializer.Deserialize<List<ChartProductDTO>>(chartWithMetaDataProducts.Products);
            
            List<ProductDTO> products = new List<ProductDTO>();
            foreach(var productId in productsWithIds)
            {
                // read all data about products
                var product = await _productRepository.GetProductByIdBaseInfo(productId.ProductId);
                products.Add(product);
            }

            return chartWithMetaDataProducts.getActiveChart(products);
        }
    }
}
