using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Volt.Application.Services;

namespace Volt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}