using Microsoft.Extensions.DependencyInjection;

namespace Charts.Mediator
{
    public static class ChartDIMediator
    {
        public static IServiceCollection AddChartMediator(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ChartDIMediator).Assembly));
            return services;
        }
    }
}
