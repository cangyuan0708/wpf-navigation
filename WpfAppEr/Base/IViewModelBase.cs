namespace WpfAppEr.Base;

public interface IViewModelBase
{
    Task OnNavigatedToAsync(object? parameter = null);
    Task OnNavigatedFromAsync();
}
