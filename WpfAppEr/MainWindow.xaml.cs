using KernelBaseLibrary.Contracts.Services;
using System.Windows;
using WpfAppEr.Views.Page;
using WpfAppEr.Views.Popup;

namespace WpfAppEr;

public partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;

    private readonly IOverlayService _overlayService;

    public MainWindow(INavigationService navigationService, IOverlayService overlayService)
    {
        InitializeComponent();

        _navigationService = navigationService;
        _overlayService = overlayService;

        _navigationService.Initialize(Transitioner, view =>
        {
            Transitioner.Content = view;
        });

        _navigationService.Register<MainPage>(nameof(MainPage));
        _navigationService.Register<DetailPage>(nameof(DetailPage));

        _overlayService.Initialize(view =>
        {
            if (view is null)
            {
                PopupOverlay.Visibility = Visibility.Collapsed;
                PopupHost.Content = null;
            }
            else
            {
                PopupOverlay.Visibility = Visibility.Visible;
                PopupHost.Content = view;
            }
        });
        _overlayService.Register<MyPopupView>("MyPopup");
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await _navigationService.NavigateToAsync(nameof(MainPage));
    }
}