using Persons.Infrastructure;
using Persons.Infrastructure.implementation;
using Persons.Mediator;
using Products.Infrastructure;
using Products.Infrastructure.implementation;
using Products.Mediator;

namespace WebShopApi
{
    public static class ExtensionService
    {
        public static IServiceCollection AddPersonDI(this IServiceCollection services)
        {
            services.AddScoped<PersonDbContext>();
            services.AddScoped<IPersonRepository,PersonRepository>();
            services.AddPersonMediator();
            return services;
        }
        public static IServiceCollection AddProductDI(this IServiceCollection services)
        {
            services.AddScoped<ProductDbContext>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddProductMediator();

            return services;
        }
    }
}
