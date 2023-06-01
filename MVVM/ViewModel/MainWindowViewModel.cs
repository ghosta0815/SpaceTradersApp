using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.View;

namespace SpaceTradersApp.MVVM.ViewModel;

public class MainWindowViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand ShipViewCommand { get; set; }

    public ShipViewModel ShipVM { get; set; }

    public HomeViewModel HomeVM { get; set; }

    private object _currentView;

    private string _balance = "400 C";

    public string Balance
    {
        get { return _balance; }
        set { _balance = value; OnPropertyChanged(); }
    }


    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        CurrentView = IoCContainer.MyServiceProvider.GetRequiredService<HomeView>();

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = IoCContainer.MyServiceProvider.GetRequiredService<HomeView>();
        });

        ShipViewCommand = new RelayCommand(o =>
        {
            CurrentView = IoCContainer.MyServiceProvider.GetRequiredService<ShipView>();
        });
    }
}
