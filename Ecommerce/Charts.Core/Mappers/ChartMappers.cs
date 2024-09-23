using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Charts.Core.DTOs;
using Products.Core.DTOs;

namespace Charts.Core.Mappers
{
    public static  class ChartMappers
    {
        public static ChartDTO getActiveChart(this ChartRawDTO chartRawDTO,List<ProductDTO> products)
        {
            return new ChartDTO
            {
                Id = chartRawDTO.Id,
                PersonId = chartRawDTO.PersonId,
                Products = products,
                Total = products.Sum(p => p.Price)
            };
        }

        public static ChartRawDTO toRawChart(this ChartDTO chartDTO)
        {
            return new ChartRawDTO
            {
                Id = chartDTO.Id,
                PersonId = chartDTO.PersonId,
                Products = JsonSerializer.Serialize(chartDTO.Products.Select(p=>p.toBaseProduct())),
            };
        }

        public static ChartProductDTO toBaseProduct(this ProductDTO product)
        {
            return new ChartProductDTO
            {
                ProductId = product.Id,
            };
        }

        public static ChartHistoryDTO toChartHistory(this ChartDTO chartDTO)
        {
            return new ChartHistoryDTO
            {
                PersonId = chartDTO.PersonId,
                Total = chartDTO.Total,
                Products = JsonSerializer.Serialize(chartDTO.Products),
                Status = chartDTO.Status
            };
        }
    }
}
