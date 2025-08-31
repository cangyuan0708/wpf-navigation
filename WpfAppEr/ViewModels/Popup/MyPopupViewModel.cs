using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KernelBaseLibrary.Contracts.Services;
using KernelBaseLibrary.Definitions.Base;

namespace WpfAppEr.ViewModels.Popup;

public partial class MyPopupViewModel(IOverlayService overlayService) : PopupViewModelBase
{
    [ObservableProperty] private string? message;

    public override async Task OnOpendToAsync(object? parameter)
    {
        await Task.CompletedTask;
        if (parameter is string msg)
            Message = msg;
    }

    [RelayCommand]
    private void Close()
    {
        overlayService.Close();
    }
}
