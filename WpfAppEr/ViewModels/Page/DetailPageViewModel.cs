using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KernelBaseLibrary.Contracts.Services;
using KernelBaseLibrary.Definitions.Base;

namespace WpfAppEr.ViewModels.Page;

public partial class DetailPageViewModel(INavigationService navigationService, IOverlayService overlayService) : PageViewModelBase
{
    private int _id;

    [ObservableProperty] private string? detailData;

    public override async Task OnNavigatedToAsync(object? parameter = null)
    {
        await Task.CompletedTask;
        if (parameter is int id)
        {
            _id = id;
            LoadData(_id);
        }
    }

    private void LoadData(int id)
    {
        DetailData = $"Loaded detail for ID: {id}";
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await navigationService.GoBackAsync();
    }

    [RelayCommand]
    private async Task OpenPopup()
    {
        await overlayService.OpenAsync("MyPopup", "Hello from Main");
    }

    public override async Task OnNavigatedFromAsync()
    {
        await Task.CompletedTask;
    }
}
