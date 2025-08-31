using CommunityToolkit.Mvvm.ComponentModel;
using KernelBaseLibrary.Contracts.Base;

namespace KernelBaseLibrary.Definitions.Base;

public abstract partial class PopupViewModelBase : ObservableObject, IPopupViewModelBase
{
    public virtual Task OnOpendToAsync(object? parameter = null) => Task.CompletedTask;
}
