using CommunityToolkit.Mvvm.ComponentModel;
using WpfAppEr.Services;

namespace WpfAppEr.Base
{
    public abstract partial class BaseViewModel(INavigationService navigationService) : ObservableObject
    {
        protected readonly INavigationService NavigationService = navigationService;

        public virtual Task OnNavigatedToAsync(object? parameter = null) => Task.CompletedTask;
    }
}
