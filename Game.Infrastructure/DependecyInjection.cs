using Game.Application.Common.Interfaces.Persistence;
using Game.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // depency injection for the application db context
            services.AddDbContext<GameDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("GameConnection")));

            services.AddScoped<IGameDbContext>(provider => provider.GetService<GameDbContext>());





            return services;
        }
    }
}
