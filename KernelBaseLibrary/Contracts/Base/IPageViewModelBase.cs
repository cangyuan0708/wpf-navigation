namespace KernelBaseLibrary.Contracts.Base;

public interface IPageViewModelBase
{
    Task OnNavigatedToAsync(object? parameter = null);
    Task OnNavigatedFromAsync();
}
