using Microsoft.Extensions.DependencyInjection;
using NovelSys.Application.Common.Interfaces.Authentication;
using NovelSys.Infrastructure.Authentication;



namespace NovelSys.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;

        }
    }
}
