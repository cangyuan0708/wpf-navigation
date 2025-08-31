using System.Windows.Controls;
using WpfAppEr.ViewModels.Page;

namespace WpfAppEr.Views.Page;

public partial class DetailPage : UserControl
{
    public DetailPage(DetailPageViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
