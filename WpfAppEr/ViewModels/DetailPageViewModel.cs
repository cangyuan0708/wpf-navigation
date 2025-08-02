using CommunityToolkit.Mvvm.Input;
using WpfAppEr.Base;
using WpfAppEr.Services;

namespace WpfAppEr.ViewModels;

public partial class DetailPageViewModel(INavigationService navigationService) : BaseViewModel(navigationService)
{
    private int _id;
    public string? DetailData { get; private set; }

    public override void OnNavigatedTo(object? parameter = null)
    {
        if (parameter is int id)
        {
            _id = id;
            LoadData(_id);
        }
    }

    private void LoadData(int id)
    {
        DetailData = $"Loaded detail for ID: {id}";
        OnPropertyChanged(nameof(DetailData));
    }

    [RelayCommand]
    private void GoBack()
    {
        NavigationService.GoBack();
    }
}
