using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Products.Core.DTOs;
using Products.Core.Mappers;

namespace Products.Infrastructure.implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAppleProducts()
        {
            var query = $"SELECT * FROM {ProductsOperations.GET_APPLE_PRODUCTS}";
            var appleProducts = _context.Products.FromSqlRaw(query);
            return  await appleProducts.ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts(int offset,int next)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Offset",offset),
                    new SqlParameter("@Next",next)
                };
            var allProducts = await _context.GetEntitiesByStoredProcedure<ProductDTO>(ProductsOperations.GET_ALL_PRODUCTS,parameters);
            return allProducts;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsByCategory(Guid categoryId, int offset, int next)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@CategoryId",categoryId),
                    new SqlParameter("@Offset",offset),
                    new SqlParameter("@Next",next)
                };
            var productsByCategory = await _context.GetEntitiesByStoredProcedure<ProductDTO>
                (ProductsOperations.GET_PRODUCTS_BY_CATEGORY, parameters);
            return productsByCategory;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsBySubCategory(Guid subCategoryId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@SubCategoryId",subCategoryId)
            };

            var productsBySubCategory = await _context.GetEntitiesByStoredProcedure<ProductDTO>
                (ProductsOperations.GET_PRODUCTS_BY_SUBCATEGORY, parameters);

            return productsBySubCategory;
        }

        public async Task<ProductFullDTO> GetProductById(Guid productId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId)
            };
            var productByIdRaw = await _context.GetEntityByStoredProcedure<ProductFullRawDTO>
                (ProductsOperations.GET_PRODUCT_BY_ID, parameters);
            return productByIdRaw.mapProductRawToProductFull();
        }
    }
}
