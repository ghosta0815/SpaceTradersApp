using SpaceTradersApp.MVVM.ViewModel;
using System.Windows;

namespace SpaceTradersApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}
