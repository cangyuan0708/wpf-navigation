using CommunityToolkit.Mvvm.ComponentModel;
using WpfAppEr.Services;

namespace WpfAppEr.Base;

public abstract partial class ViewModelBase(INavigationService navigationService) : ObservableObject, IViewModelBase
{
    protected readonly INavigationService NavigationService = navigationService;

    public virtual Task OnNavigatedToAsync(object? parameter = null) => Task.CompletedTask;
    public virtual Task OnNavigatedFromAsync() => Task.CompletedTask;
}
