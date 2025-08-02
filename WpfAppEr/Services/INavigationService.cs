using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace WpfAppEr.Services;

public interface INavigationService
{
    void Initialize(TransitioningContentControl contentControl, Action<UserControl> setViewAction);
    void Register<TView>(string viewName) where TView : UserControl;
    Task NavigateToAsync(string viewName, object? parameter = null);
    Task GoBackAsync();
    Task GoHomeAsync();
}
