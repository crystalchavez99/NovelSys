using Microsoft.Extensions.DependencyInjection;
using NovelSys.Application.Services.Authentication;

namespace NovelSys.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
           services.AddScoped<IAuthenticationService, AuthenticationService>();
         return services;

        }
    }
}
