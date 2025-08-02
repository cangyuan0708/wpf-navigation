using System.Windows.Controls;
using WpfAppEr.Base;

namespace WpfAppEr.Services;

public interface INavigationService
{
    void SetViewAction(Action<UserControl> setViewAction);
    void NavigateTo(string viewName, object? parameter = null);
    void Register<TView, TViewModel>(string viewName) where TView : UserControl where TViewModel : BaseViewModel;
    void GoBack();
    void GoHome();
}
