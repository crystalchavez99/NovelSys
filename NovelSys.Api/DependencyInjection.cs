using NovelSys.Api.Common.Mapping;

namespace NovelSys.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        return services;
    }
}

