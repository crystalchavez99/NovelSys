using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Common;
using NovelSys.Application.Common.Behaviors;
using System.Reflection;

namespace NovelSys.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidateRegisterCommandBehavior>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}

