using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure;
using Products.Mediator;
using Products.Service.implementation;

namespace Products.Service
{
    public static class ProductDIConfiguration
    {
        public static IServiceCollection AddProductDI(this IServiceCollection services)
        {
            services.AddScoped<ProductDbContext>();
            services.AddScoped<IDbOperations<ProductDbContext>, DbOperations<ProductDbContext>>();
            services.AddScoped<IProductService,ProductServiceMediator>();

            services.AddProductMediator();

            return services;
        }
    }
}
