using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure
{
    public interface ProductsOperations
    {
        public const string GET_PRODUCTS_BY_SUBCATEGORY = "dbo.GetProductsBySubCategory";
        public const string GET_PRODUCTS_BY_CATEGORY = "dbo.GetProductsByCategory";
        public const string GET_ALL_PRODUCTS = "dbo.GetAllProducts";
        public const string GET_PRODUCT_BY_ID = "dbo.GetProductById";
        public const string GET_APPLE_PRODUCTS = "dbo.GetAppleProducts";
        public const string GET_SAMSUNG_PRODUCTS = "dbo.GetSamsungProducts";
    }
}
