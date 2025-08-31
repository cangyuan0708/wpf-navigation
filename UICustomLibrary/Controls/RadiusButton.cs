using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UICustomLibrary.Controls;

public partial class RadiusButton : Button
{
    static RadiusButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RadiusButton),
            new FrameworkPropertyMetadata(typeof(RadiusButton)));
    }

    #region Dependency Properties
    public static readonly DependencyProperty HoverBackgroundProperty =
        DependencyProperty.Register(
            nameof(HoverBackground),
            typeof(Brush),
            typeof(RadiusButton),
            new PropertyMetadata(Brushes.White)
        );
    #endregion

    #region Properties
    public Brush HoverBackground
    {
        get { return (Brush)GetValue(HoverBackgroundProperty); }
        set { SetValue(HoverBackgroundProperty, value); }
    }
    #endregion
}
