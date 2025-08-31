using System.Windows.Controls;
using WpfAppEr.ViewModels.Popup;

namespace WpfAppEr.Views.Popup;

public partial class MyPopupView : UserControl
{
    public MyPopupView(MyPopupViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
