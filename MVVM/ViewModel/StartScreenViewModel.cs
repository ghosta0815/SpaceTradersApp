using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Windows.Input;

namespace SpaceTradersApp.MVVM.ViewModel;

public class StartScreenViewModel : ViewModelBase
{
    #region Commands
    /// <summary>
    /// Continues the game with the player agent of the provided bearer Token
    /// </summary>
    public IAsyncCommand ContinueGameCommand { get; set; }

    /// <summary>
    /// Registers a new player agent and creates a new bearer token
    /// </summary>
    public IAsyncCommand RegisterAgentCommand { get; set; }

    /// <summary>
    /// Saves the Bearer Token
    /// </summary>
    public RelayCommand SaveTokenCommand { get; set; }

    /// <summary>
    /// Loads the Bearer Token
    /// </summary>
    public RelayCommand LoadTokenCommand { get; set; }
    #endregion

    #region private Members
    private string _bearerToken = "";

    private bool _continueButtonEnabled = true;

    private string _statusMessage = "";

    private ListCollectionView? _factionList;

    private string? _selectedFaction;

    private string _agentName = "";
    #endregion

    #region public Members
    /// <summary>
    /// The Statustext when Loading a user Agent
    /// </summary>
    public string StatusMessage
    {
        get { return _statusMessage; }
        set { _statusMessage = value; OnPropertyChanged(nameof(StatusMessage)); }
    }

    /// <summary>
    /// If the continue button and agent registration buttons can be clicked, false if it is currently connecting to or 
    /// creating an agent
    /// </summary>
    public bool AccountButtonsEnabled
    {
        get { return _continueButtonEnabled; }
        set { _continueButtonEnabled = value; OnPropertyChanged(nameof(AccountButtonsEnabled)); }
    }

    /// <summary>
    /// The list of available factions in the game
    /// </summary>
    public ListCollectionView? FactionList
    {
        get { return _factionList; }
        set { _factionList = value; OnPropertyChanged(nameof(FactionList)); }
    }

    /// <summary>
    /// The selected Faction for account creation
    /// </summary>
    public string? SelectedFaction
    {
        get { return _selectedFaction; }
        set { _selectedFaction = value; OnPropertyChanged(nameof(SelectedFaction)); System.Diagnostics.Debug.WriteLine(value); }
    }

    /// <summary>
    /// The bearer token to connect to the User agent
    /// </summary>
    public string BearerToken
    {
        get { return _bearerToken; }
        set
        {
            if (value != BearerToken)
            {
                _bearerToken = value;
                OnPropertyChanged(nameof(BearerToken));
            }
        }
    }

    /// <summary>
    /// The name of the player agent for new account creation
    /// </summary>
    public string AgentName
    {
        get { return _agentName; }
        set { _agentName = value; OnPropertyChanged(nameof(AgentName)); }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Default Constructor setting up the ViewModel with its default values and command bindings
    /// </summary>
    public StartScreenViewModel()
    {
        List<string> factionList = new List<string>() {
            "COSMIC",
            "VOID",
            "GALACTIC",
            "QUANTUM",
            "DOMINION",
            "ASTRO",
            "CORSAIRS",
            "OBSIDIAN",
            "AEGIS",
            "UNITED",
            "SOLIDARY",
            "COBALT",
            "OMEGA",
            "ECHO",
            "LORDS",
            "CULT",
            "ANCIENTS",
            "SHADOW",
            "ETHEREAL"
        };
        _factionList = new ListCollectionView(factionList);

        _selectedFaction = factionList[0];

        ContinueGameCommand = new AsyncCommand(async () =>
        {
            await ContinueGameAsync();
        });

        RegisterAgentCommand = new AsyncCommand(async () =>
        {
            await RegisterAgentAsync();
        });

        SaveTokenCommand = new RelayCommand(o =>
        {
            var mainWindow = IoCContainer.Services.GetRequiredService<MainWindowViewModel>();
            if (mainWindow.LoggedIn) IoCContainer.TokenFileHandler.WriteTokenToFile(BearerToken, AgentName);
        });

        LoadTokenCommand = new RelayCommand(o =>
        {
            BearerToken = IoCContainer.TokenFileHandler.ReadTokenFromFile();
        });

    }
    #endregion

    #region Async Task
    /// <summary>
    /// Method to continue the game, requires Bearer Token
    /// </summary>
    private async Task ContinueGameAsync()
    {
        AccountButtonsEnabled = false;
        StatusMessage = "loading...";
        IoCContainer.SpaceTradersAPI.Token = BearerToken;
        AgentModel? agent = await IoCContainer.SpaceTradersAPI.getMyAgentAsync();

        MainWindowViewModel mainWindowVM = IoCContainer.Services.GetRequiredService<MainWindowViewModel>();

        if (agent == null)
        {
            AgentName = "";
            AccountButtonsEnabled = true;
            StatusMessage = "Invalid Token";
            mainWindowVM.AccountName = "-";
            mainWindowVM.Balance = "-";
            mainWindowVM.LoggedIn = false;
            return;
        }

        AgentName = agent.Symbol!;
        mainWindowVM.AccountName = agent.Symbol!;
        mainWindowVM.Balance = agent.Credits.ToString()!;
        mainWindowVM.LoggedIn = true;
        AccountButtonsEnabled = true;
        StatusMessage = "Logged in";
        

    }

    /// <summary>
    /// Method to register a new agent, requires valid agent data
    /// </summary>
    private async Task RegisterAgentAsync()
    {
        if (IsAccountDataInvalid()) return;

        AccountButtonsEnabled = false;
        StatusMessage = "Registering new account...";

        AccountModel? account = await IoCContainer.SpaceTradersAPI.RegisterNewAccountAsync(AgentName, SelectedFaction);

        MainWindowViewModel mainWindowVM = IoCContainer.Services.GetRequiredService<MainWindowViewModel>();
        if (account == null)
        {
            AccountButtonsEnabled = true;
            StatusMessage = "Account could not be created";
            mainWindowVM.AccountName = "-";
            mainWindowVM.Balance = "-";
            mainWindowVM.LoggedIn = false;
            return;
        }
        mainWindowVM.AccountName = account.Agent!.Symbol!;
        mainWindowVM.Balance = account.Agent.Credits.ToString()!;
        mainWindowVM.LoggedIn = true;
        StatusMessage = "Account created";
        AccountButtonsEnabled = true;
        BearerToken = account!.Token!;
        IoCContainer.SpaceTradersAPI.Token = BearerToken;
    }
    #endregion

    #region private Methods
    /// <summary>
    /// Checks if the provided Agent registration Data is valid
    /// AgentName >= 3 and <= 14
    /// </summary>
    /// <returns>True if the Registration data is valid</returns>
    private bool IsAccountDataInvalid()
    {
        if (AgentName.Length < 3) return true;
        if (AgentName.Length > 15) return true;
        return false;
    }

    #endregion
}
