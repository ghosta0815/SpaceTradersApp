using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.ViewModel;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View;

/// <summary>
/// Interaction logic for StartScreenView.xaml
/// </summary>
public partial class StartScreenView : UserControl
{
    public StartScreenView(StartScreenViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
