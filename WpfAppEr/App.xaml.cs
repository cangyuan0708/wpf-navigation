using KernelBaseLibrary;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfAppEr;

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureServices();
        ServiceProvider = serviceCollection.BuildServiceProvider();

        MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
