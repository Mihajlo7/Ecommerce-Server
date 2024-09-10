using Products.Core.DTOs;

namespace Products.Service
{
    public interface IProductService
    {
        public Task<ProductFullDTO> GetProductById(Guid id);
        public Task<IEnumerable<ProductDTO>> GetAllProducts(int page=1);
        public Task<IEnumerable<ProductDTO>> GetProductsBySubCategory(Guid subCategoryId);
        public Task<IEnumerable<ProductDTO>> GetProductsByCategory(Guid categoryId,int page=1);
        public Task<IEnumerable<ProductDTO>> GetSamsungProducts();
        public Task<IEnumerable<ProductDTO>> GetAppleProducts();
    }
}
