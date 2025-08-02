using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using WpfAppEr.Base;

namespace WpfAppEr.Services;

public class NavigationService(IServiceProvider serviceProvider) : INavigationService
{
    private readonly Dictionary<string, (Type ViewType, Type ViewModelType)> _map = [];
    private readonly Stack<(string ViewName, object? Parameter)> _navigationHistory = new();
    private Action<UserControl>? _setViewAction;
    private UserControl? _currentView = null;

    public void SetViewAction(Action<UserControl> setViewAction) => _setViewAction = setViewAction;

    public void Register<TView, TViewModel>(string viewName) where TView : UserControl where TViewModel : BaseViewModel => _map[viewName] = (typeof(TView), typeof(TViewModel));

    public void NavigateTo(string viewName, object? parameter = null)
    {
        if (_navigationHistory.Count > 0 && _navigationHistory.Peek().ViewName == viewName)
            _navigationHistory.Pop();

        _navigationHistory.Push((viewName, parameter));
        NavigateCore(viewName, parameter);
    }

    public void GoBack()
    {
        if (_navigationHistory.Count > 1)
        {
            _navigationHistory.Pop();
            var (viewName, parameter) = _navigationHistory.Peek();
            NavigateCore(viewName, parameter);
        }
    }

    public void GoHome()
    {
        if (_navigationHistory.Count > 1)
        {
            var first = _navigationHistory.Last();
            _navigationHistory.Clear();
            _navigationHistory.Push(first);
            var (viewName, parameter) = _navigationHistory.Peek();
            NavigateCore(viewName, parameter);
        }
    }

    private void NavigateCore(string viewName, object? parameter = null)
    {
        if (!_map.TryGetValue(viewName, out var types))
            throw new InvalidOperationException($"View '{viewName}' is not registered.");

        if (_currentView != null)
        {
            var oldDataContext = _currentView.DataContext;
            _currentView.DataContext = null;

            if (oldDataContext is IDisposable disposableOldVm)
                disposableOldVm.Dispose();
        }

        var view = (UserControl)serviceProvider.GetRequiredService(types.ViewType);
        var viewModel = (BaseViewModel)serviceProvider.GetRequiredService(types.ViewModelType);
        view.DataContext = viewModel;        

        _currentView = view;
        _setViewAction?.Invoke(view);
        viewModel.OnNavigatedTo(parameter);
    }
}
