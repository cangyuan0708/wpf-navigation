using System.Windows;
using WpfAppEr.Services;
using WpfAppEr.ViewModels;
using WpfAppEr.Views;

namespace WpfAppEr;

public partial class MainWindow : Window
{
    public MainWindow(INavigationService navigationService) 
    {
        InitializeComponent();

        navigationService.SetViewAction(view => Transitioner.Content = view);
        navigationService.Register<MainPage, MainPageViewModel>(nameof(MainPage));
        navigationService.Register<DetailPage, DetailPageViewModel>(nameof(DetailPage));
        navigationService.NavigateTo(nameof(MainPage));
    }
}