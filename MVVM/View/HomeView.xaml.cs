using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.ViewModel;
using System.Windows.Controls;

namespace SpaceTradersApp.MVVM.View;

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
public partial class HomeView : UserControl
{
    public HomeView(HomeViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
