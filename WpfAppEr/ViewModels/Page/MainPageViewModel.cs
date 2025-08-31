using CommunityToolkit.Mvvm.Input;
using KernelBaseLibrary.Contracts.Services;
using KernelBaseLibrary.Definitions.Base;
using WpfAppEr.Views.Page;

namespace WpfAppEr.ViewModels.Page;

public partial class MainPageViewModel(INavigationService navigationService) : PageViewModelBase
{
    [RelayCommand]
    private async Task GoToDetail()
    {
        int exampleId = 123;
        await navigationService.NavigateToAsync(nameof(DetailPage), exampleId);
    }
}
