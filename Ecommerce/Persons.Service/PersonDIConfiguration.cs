using DBOperations;
using Microsoft.Extensions.DependencyInjection;
using Persons.Infrastructure;
using Persons.Mediator;
using Persons.Service.implementation;

namespace Persons.Service
{
    public static class PersonDIConfiguration
    {
        public static IServiceCollection AddDIPersons(this IServiceCollection services)
        {
            services.AddScoped<PersonDbContext>();
            services.AddScoped<IDbOperations<PersonDbContext>, DbOperations<PersonDbContext>>();
            services.AddScoped<IPersonService,PersonService>();

            services.AddPersonMediator();

            return services;
        }
    }
}
