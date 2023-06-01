using SpaceTradersApp.MVVM.ViewModel;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View;

/// <summary>
/// Interaction logic for ShipView.xaml
/// </summary>
public partial class ShipView : UserControl
{
    public ShipView(ShipViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
