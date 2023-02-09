using Common.Dto_s;
using DBContext;
using Microsoft.Extensions.DependencyInjection;
using Properties;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IDataService<UserDto>, UserService>();
            services.AddSingleton<IContext, MyDBContext>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
