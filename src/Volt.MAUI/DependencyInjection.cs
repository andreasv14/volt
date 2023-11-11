using Refit;
using Volt.MAUI.Pages;
using Volt.MAUI.Services;
using Volt.MAUI.ViewModels;

namespace Volt.MAUI;

public static class DependencyInjection
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<RegisterViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<HomeViewModel>();
        return services;
    }
    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<RegisterPage>();
        services.AddSingleton<LoginPage>();
        services.AddSingleton<HomePage>();
        services.AddSingleton<SettingsPage>();
        return services;
    }

    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        services
            .AddRefitClient<IAccountService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7107"));

        return services;
    }
}