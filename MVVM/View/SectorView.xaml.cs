using SpaceTradersApp.MVVM.Model;
using SpaceTradersApp.MVVM.ViewModel;
using System;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View;

/// <summary>
/// Interaction logic for ShipView.xaml
/// </summary>
public partial class SectorView : UserControl
{
    public SectorView(SectorViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }

}
