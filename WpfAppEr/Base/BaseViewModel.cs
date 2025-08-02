using CommunityToolkit.Mvvm.ComponentModel;
using WpfAppEr.Services;

namespace WpfAppEr.Base
{
    public abstract partial class BaseViewModel(INavigationService navigationService) : ObservableObject
    {
        protected readonly INavigationService NavigationService = navigationService;

        public virtual void OnNavigatedTo(object? parameter = null) { }
    }
}
