using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using SpaceTradersApp.MVVM.View;
using System;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    #region Commands
    /// <summary>
    /// RelayCommand for setting the Home View
    /// </summary>
    public RelayCommand HomeViewCommand { get; set; }

    /// <summary>
    /// Command for switching to the Fleet View
    /// </summary>
    public IAsyncCommand FleetViewCommand { get; set; }
    #endregion

    #region private Variables
    /// <summary>
    /// The Name of the Account
    /// </summary>
    private string _accountName = "-";

    /// <summary>
    /// The balance of the Account
    /// </summary>
    private string _balance = "-";

    /// <summary>
    /// The currently displayed view
    /// </summary>
    private object _currentView;

    /// <summary>
    /// True if the user provided a valid token
    /// </summary>
    private bool _loggedIn = false;
    #endregion

    #region public Properties
    /// <summary>
    /// The name of the User Agent for the token
    /// </summary>
    public string AccountName
    {
        get { return _accountName; }
        set { 
            _accountName = value;
            OnPropertyChanged(nameof(AccountName));
        }
    }

    /// <summary>
    /// The current balance of the User Agent for the provided token
    /// </summary>
    public string Balance
    {
        get { return _balance; }
        set { 
            _balance = value + " C";
            OnPropertyChanged(nameof(Balance)); 
        }
    }

    /// <summary>
    /// The currently displayed view in the Main Windows
    /// </summary>
    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Is true if the provided token is valid and the user logged in
    /// </summary>
    public bool LoggedIn
    {
        get { return _loggedIn; }
        set { _loggedIn = value; OnPropertyChanged(nameof(LoggedIn)); }
    }
    #endregion

    #region Constructors

    /// <summary>
    /// Default Constructor
    /// </summary>
    public MainWindowViewModel()
    {
        _currentView = IoCContainer.Services.GetRequiredService<HomeView>();

        HomeViewCommand = new RelayCommand(o =>
        {
            CurrentView = IoCContainer.Services.GetRequiredService<HomeView>();
        });

        FleetViewCommand = new AsyncCommand(async () =>
        {
            CurrentView = IoCContainer.Services.GetRequiredService<FleetView>();
            await LoadFleetAsync();
        });
    }

    /// <summary>
    /// Loads the List of Ships
    /// </summary>
    /// <returns></returns>
    private async Task LoadFleetAsync()
    {
        var shipModelResponse = await IoCContainer.SpaceTradersAPI.getShipsDataAsync();
        IoCContainer.Services.GetRequiredService<FleetViewModel>().DisplayShipList(shipModelResponse);
    }
    #endregion
}
