using CommunityToolkit.Mvvm.ComponentModel;
using KernelBaseLibrary.Contracts.Base;

namespace KernelBaseLibrary.Definitions.Base;

public abstract partial class PageViewModelBase : ObservableObject, IPageViewModelBase
{
    public virtual Task OnNavigatedToAsync(object? parameter = null) => Task.CompletedTask;
    public virtual Task OnNavigatedFromAsync() => Task.CompletedTask;
}
