using System.Windows;
using WpfAppEr.Services;
using WpfAppEr.Views;

namespace WpfAppEr;

public partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;

    public MainWindow(INavigationService navigationService) 
    {
        InitializeComponent();
        _navigationService = navigationService;
        _navigationService.Initialize(Transitioner, view => Transitioner.Content = view);
        _navigationService.Register<MainPage>(nameof(MainPage));
        _navigationService.Register<DetailPage>(nameof(DetailPage));
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await _navigationService.NavigateToAsync(nameof(MainPage));
    }
}