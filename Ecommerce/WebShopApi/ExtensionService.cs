using Charts.Infrastructure;
using Charts.Infrastructure.implementation;
using Charts.Mediator;
using Persons.Infrastructure;
using Persons.Infrastructure.implementation;
using Persons.Mediator;
using Products.Infrastructure;
using Products.Infrastructure.implementation;
using Products.Mediator;
using WebShopApi.ExceptionHandlers;

namespace WebShopApi
{
    public static class ExtensionService
    {
        public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<SqlExceptionHandler>();

            return services;
        }
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

        public static IServiceCollection AddChartDI (this IServiceCollection services)
        {
            services.AddScoped<ChartDbContext>();
            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IHistoryChartRepository, HistoryChartRepository>();
            services.AddChartMediator();

            return services;
        }

    }
}
