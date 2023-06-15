using SpaceTradersApp.MVVM.Model;
using SpaceTradersApp.MVVM.ViewModel;
using System;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View;

/// <summary>
/// Interaction logic for ShipView.xaml
/// </summary>
public partial class FleetView : UserControl
{
    public FleetView(FleetViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }

}
