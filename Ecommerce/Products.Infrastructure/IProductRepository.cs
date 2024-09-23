using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Core.DTOs;

namespace Products.Infrastructure
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsBySubCategory(Guid subCategoryId);
        Task<IEnumerable<ProductDTO>> GetAllProductsByCategory(Guid categoryId, int offset, int next);
        Task<IEnumerable<ProductDTO>> GetAllProducts(int offset,int next);
        Task<ProductFullDTO> GetProductById(Guid productId);
        Task<ProductDTO> GetProductByIdBaseInfo(Guid productId);
        Task<IEnumerable<ProductDTO>> GetAllAppleProducts();
    }
}
