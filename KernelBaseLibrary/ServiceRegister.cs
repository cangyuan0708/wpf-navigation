using KernelBaseLibrary.Contracts.Services;
using KernelBaseLibrary.Definitions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KernelBaseLibrary;

public static class ServiceRegister
{
    public static IServiceCollection AddKernelBase(this IServiceCollection services)
    {
        services
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<IOverlayService, OverlayService>();
        return services;
    }
}
