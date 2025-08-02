using System.Windows.Controls;
using WpfAppEr.ViewModels;

namespace WpfAppEr.Views;

public partial class DetailPage : UserControl
{
    public DetailPage(DetailPageViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
