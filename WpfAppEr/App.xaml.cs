using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppEr.Services;
using WpfAppEr.ViewModels;
using WpfAppEr.Views;

namespace WpfAppEr;

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IServiceCollection serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();

        MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddTransient<MainWindow>()
            .AddSingleton<INavigationService, NavigationService>()
            .AddTransient<MainPageViewModel>()
            .AddTransient<DetailPageViewModel>()
            .AddTransient<MainPage>()
            .AddTransient<DetailPage>();
    }
}
