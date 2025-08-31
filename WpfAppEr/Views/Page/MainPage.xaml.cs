using System.Windows.Controls;
using WpfAppEr.ViewModels.Page;

namespace WpfAppEr.Views.Page;

public partial class MainPage : UserControl
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
