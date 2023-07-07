using Game.Api.Errors;
using Game.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Game.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory,GameProblemDetailsFactory >();
            services.AddMapping();
            return services;
        }
    }
}
