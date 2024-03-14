using Microsoft.Extensions.DependencyInjection;
using NovelSys.Application.Services.Authentication;
using NovelSys.Application.Services.Authentication.Commands;

namespace NovelSys.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
           services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;

        }
    }
}
