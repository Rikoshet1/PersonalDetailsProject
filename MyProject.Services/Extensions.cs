using Microsoft.Extensions.DependencyInjection;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IPersonRepository, PersonRepository  >();
            services.AddScoped<IChildRepository, ChildRepository>();

            return services;
        }
    }
}
