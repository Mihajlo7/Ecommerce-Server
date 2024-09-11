using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Products.Core.DTOs;

namespace Products.Core.Mappers
{
    public static class ProductMapper
    {
        public static ProductFullDTO mapProductRawToProductFull(this ProductFullRawDTO productFullRaw)
        {
            return new ProductFullDTO
            {
                Id = productFullRaw.Id,
                ProductNumber = productFullRaw.ProductNumber,
                Name = productFullRaw.Name,
                ShortDescription = productFullRaw.ShortDescription,
                LongDescription = productFullRaw.LongDescription,
                Color = productFullRaw.Color,
                Size = JsonSerializer.Deserialize<SizeDTO>(productFullRaw.Size),
                Weight = JsonSerializer.Deserialize<WeightDTO>(productFullRaw.Weight),
                Image = productFullRaw.Image,
                Price = productFullRaw.Price,
                Status = productFullRaw.Status,
                SubCategory = new SubCategoryDTO
                {
                    Id = productFullRaw.SubCategoryId,
                    Number = productFullRaw.SubCategoryNumber,
                    Name = productFullRaw.SubCategoryName,

                },
                Category = new CategoryDTO
                {
                    Id = productFullRaw.CategoryId,
                    Number = productFullRaw.CategoryNumber,
                    Name = productFullRaw.CategoryName,
                }
            };
        }
    }
}
