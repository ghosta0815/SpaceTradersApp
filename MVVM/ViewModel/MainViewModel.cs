using SpaceTradersApp.Core;

namespace SpaceTradersApp.MVVM.ViewModel;

class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand ShipViewCommand { get; set; }

    public ShipViewModel ShipVM { get; set; }

    public HomeViewModel HomeVM { get; set; }

    private object _currentView;

    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        HomeVM = new HomeViewModel();
        ShipVM = new ShipViewModel();
        CurrentView = HomeVM;

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = HomeVM;
        });

        ShipViewCommand = new RelayCommand(o =>
        {
            CurrentView = ShipVM;
        });
    }
}
