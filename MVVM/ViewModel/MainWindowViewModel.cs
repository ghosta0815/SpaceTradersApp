using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.View;

namespace SpaceTradersApp.MVVM.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    #region Commands
    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand ShipViewCommand { get; set; }
    #endregion

    #region ViewModels

    public ViewModelBase ShipVM { get; set; }

    public ViewModelBase HomeVM { get; set; }

    #endregion

    #region private Variables

    private object _currentView;

    private string _balance = "-";

    private string _accountName = "-";

    #endregion

    #region public Properties
    public string AccountName
    {
        get { return _accountName; }
        set { 
            _accountName = value;
            OnPropertyChanged(nameof(AccountName));
        }
    }


    public string Balance
    {
        get { return _balance; }
        set { 
            _balance = value + " C";
            OnPropertyChanged(nameof(Balance)); 
        }
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
    #endregion

    #region Constructors

    public MainWindowViewModel()
    {
        CurrentView = IoCContainer.Services.GetRequiredService<HomeView>();

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = IoCContainer.Services.GetRequiredService<HomeView>();
        });

        ShipViewCommand = new RelayCommand(o =>
        {
            CurrentView = IoCContainer.Services.GetRequiredService<ShipView>();
        });
    }
    #endregion
}
