using System.Windows.Controls;

namespace KernelBaseLibrary.Contracts.Services;

public interface IOverlayService
{
    void Initialize(Action<UserControl?> setPopupView);
    void Register<TView>(string viewName) where TView : UserControl;
    Task OpenAsync(string viewName, object? parameter = null);
    void Close();
}
