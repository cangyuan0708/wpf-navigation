namespace KernelBaseLibrary.Contracts.Base;

public interface IPopupViewModelBase
{
    Task OnOpendToAsync(object? parameter = null);
}
