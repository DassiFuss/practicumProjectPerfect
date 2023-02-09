using Microsoft.Extensions.DependencyInjection;
using Properties.Entities;
using Properties.Interface;
using Properties.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<User>, UserRepository>();
            return services;
        }

    }
}
