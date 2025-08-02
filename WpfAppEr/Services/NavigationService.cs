using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using WpfAppEr.Base;

namespace WpfAppEr.Services;

public class NavigationService(IServiceProvider serviceProvider) : INavigationService
{
    private readonly Dictionary<string, Type> _map = [];
    private readonly Stack<(string ViewName, object? Parameter)> _navigationHistory = new();
    private UserControl? _currentView = null;

    private TransitioningContentControl? _contentControl;
    private Action<UserControl>? _setViewAction;

    public void Initialize(TransitioningContentControl contentControl, Action<UserControl> setViewAction)
    {
        _contentControl = contentControl;
        _setViewAction = setViewAction;
    }

    public void Register<TView>(string viewName) where TView : UserControl
    {
        _map[viewName] = typeof(TView);
    }

    public async Task NavigateToAsync(string viewName, object? parameter = null)
    {
        if (_navigationHistory.Count > 0 && _navigationHistory.Peek().ViewName == viewName)
        {
            _navigationHistory.Pop();
            _contentControl!.Transition = TransitionType.Default;
        }
        else
            _contentControl!.Transition = TransitionType.LeftReplace;

        _navigationHistory.Push((viewName, parameter));

        await NavigateCoreAsync(viewName, parameter);
    }

    public async Task GoBackAsync()
    {
        
        if (_navigationHistory.Count <= 1) return;
        _navigationHistory.Pop();
        var (viewName, parameter) = _navigationHistory.Peek();
        _contentControl!.Transition = TransitionType.RightReplace;
        await NavigateCoreAsync(viewName, parameter);
    }

    public async Task GoHomeAsync()
    {
        if (_navigationHistory.Count <= 1) return;
        var first = _navigationHistory.Last();
        _navigationHistory.Clear();
        _navigationHistory.Push(first);
        var (viewName, parameter) = _navigationHistory.Peek();
        _contentControl!.Transition = TransitionType.RightReplace;
        await NavigateCoreAsync(viewName, parameter);
    }

    private async Task NavigateCoreAsync(string viewName, object? parameter = null)
    {
        if (!_map.TryGetValue(viewName, out var types))
            throw new InvalidOperationException($"View '{viewName}' is not registered.");

        if (_currentView?.DataContext is IViewModelBase oldVm)
            await oldVm.OnNavigatedFromAsync();

        if (_currentView != null)
        {
            if (_currentView.DataContext is IDisposable disposableOldVm)
                disposableOldVm.Dispose();
            _currentView.DataContext = null;
        }

        var view = (UserControl)serviceProvider.GetRequiredService(types);
        if (view.DataContext is IViewModelBase viewModel)
            await viewModel.OnNavigatedToAsync(parameter);

        _currentView = view;
        _setViewAction?.Invoke(view);
    }
}
