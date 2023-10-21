using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Volt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddFluentValidation(new FluentValidationOptions
        //{
        //    LocalizationEnabled = true,
        //    LocalizationLanguageSourceName = "Volt.Application.Localization"
        //});

        return services;
    }
}