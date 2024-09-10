using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Products.Mediator
{
    public static class ProductDIMediator
    {
        public static IServiceCollection AddProductMediator(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ProductDIMediator).Assembly));
            return services;
        }
    }
}
