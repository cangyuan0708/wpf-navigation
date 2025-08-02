using System.Windows.Controls;
using WpfAppEr.ViewModels;

namespace WpfAppEr.Views
{
    public partial class MainPage : UserControl
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
