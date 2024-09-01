using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Persons.Mediator
{
    public static class PersonDIMediator
    {
        public static IServiceCollection AddPersonMediator(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(PersonDIMediator).Assembly));
            return services;
        }
    }
}
