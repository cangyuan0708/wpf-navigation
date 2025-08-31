using Microsoft.Extensions.DependencyInjection;
using WpfAppEr;
using WpfAppEr.ViewModels.Page;
using WpfAppEr.ViewModels.Popup;
using WpfAppEr.Views.Page;
using WpfAppEr.Views.Popup;

namespace KernelBaseLibrary;

public static class ServiceRegister
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services
            .AddTransient<MainWindow>()
            .AddKernelBase()
            .AddTransient<MainPageViewModel>()
            .AddTransient<DetailPageViewModel>()
            .AddTransient<MainPage>()
            .AddTransient<DetailPage>()
            .AddTransient<MyPopupViewModel>()
            .AddTransient<MyPopupView>();

        return services;
    }
}
