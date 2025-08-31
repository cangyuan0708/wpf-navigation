using KernelBaseLibrary.Contracts.Base;
using KernelBaseLibrary.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace KernelBaseLibrary.Definitions.Services;

public class OverlayService(IServiceProvider serviceProvider) : IOverlayService
{
    private readonly Dictionary<string, Type> _viewMap = [];
    private Action<UserControl?>? _setPopupView;
    private UserControl? _currentView;

    public void Initialize(Action<UserControl?> setPopupView)
    {
        _setPopupView = setPopupView;
    }

    public void Register<TView>(string viewName) where TView : UserControl => _viewMap[viewName] = typeof(TView);

    public async Task OpenAsync(string viewName, object? parameter = null)
    {
        if (!_viewMap.TryGetValue(viewName, out var viewType))
            throw new InvalidOperationException($"Popup view '{viewName}' is not registered.");

        if (_currentView is IDisposable disposableOld)
            disposableOld.Dispose();

        if (_currentView is not null)
            _currentView.DataContext = null;

        _currentView = (UserControl)serviceProvider.GetRequiredService(viewType);

        if (_currentView.DataContext is IPopupViewModelBase vm)
            await vm.OnOpendToAsync(parameter);

        _setPopupView?.Invoke(_currentView);
    }

    public void Close()
    {
        if (_currentView is IDisposable disposableOld)
            disposableOld.Dispose();

        _currentView = null;
        _setPopupView?.Invoke(null);
    }
}