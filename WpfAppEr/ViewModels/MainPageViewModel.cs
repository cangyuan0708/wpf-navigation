using CommunityToolkit.Mvvm.Input;
using WpfAppEr.Base;
using WpfAppEr.Services;
using WpfAppEr.Views;

namespace WpfAppEr.ViewModels;

public partial class MainPageViewModel(INavigationService navigationService) : BaseViewModel(navigationService)
{
    [RelayCommand]
    private void GoToDetail()
    {
        int exampleId = 123;
        NavigationService.NavigateTo(nameof(DetailPage), exampleId);
    }
}
