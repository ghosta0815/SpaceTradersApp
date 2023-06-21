using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;

namespace SpaceTradersApp.MVVM.ViewModel;

public class HomeViewModel : ViewModelBase
{
    #region Commands
    public IAsyncCommand ContinueGameCommand { get; set; }
    #endregion

    #region private Members
    private string _bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZGVudGlmaWVyIjoiR0gwU1RBIiwidmVyc2lvbiI6InYyIiwicmVzZXRfZGF0ZSI6IjIwMjMtMDYtMTAiLCJpYXQiOjE2ODY0ODE3MDgsInN1YiI6ImFnZW50LXRva2VuIn0.tOtHGNU-i1E5ic7a6koLfWkTi5J5y8WmbHLqfd75RbrZZDCQTCAovmhOiEMovsglgebVSxrjViOPTpzVCpWFlKTb7sjlsvimqlUKqYeSozVszoc5WJDiBVNNgVkI-eO4tF6DAAdTQ93EZiFfuPsgWkLZshjOUbRw8988qdKaK6ZIoAqGPfTvTTasEqjhJARpIamWOChedgFrYxfxrAokB-loYwi-SJly8_yOutkBSxrxFgEOFGfbVvg3O9_Ly2T9X5CuiyNCBU283H2jXd5NMiFWEM4_zA_WfbpzndpNO3o3w0vXwE0PPFzkN9bARIPX8Axs7T8jmVIgtPuzif5CAw";

    private bool _continueButtonEnabled = true;

    private string _statusMessage = "";

    private ListCollectionView? _factionList;
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
    /// If the continue button can be clicked, false if it is currently connecting to the agent
    /// </summary>
    public bool ContinueButtonEnabled
    {
        get { return _continueButtonEnabled; }
        set { _continueButtonEnabled = value; OnPropertyChanged(nameof(ContinueButtonEnabled)); }
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

    #endregion

    #region Constructors
    /// <summary>
    /// Default Constructor setting up the ViewModel with its default values and command bindings
    /// </summary>
    public HomeViewModel()
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

        ContinueGameCommand = new AsyncCommand(async () =>
        {
            await ContinueGameAsync();
        });
    }
    #endregion

    #region Async Task
    /// <summary>
    /// Method to continue the game, requires Bearer Token
    /// </summary>
    private async Task ContinueGameAsync()
    {
        ContinueButtonEnabled = false;
        StatusMessage = "loading...";
        IoCContainer.SpaceTradersAPI.Token = BearerToken;
        AccountModel? account = await IoCContainer.SpaceTradersAPI.getMyAgentAsync();

        MainWindowViewModel mainWindowVM = IoCContainer.Services.GetRequiredService<MainWindowViewModel>();

        if (account == null)
        {
            ContinueButtonEnabled = true;
            StatusMessage = "Invalid Token";
            mainWindowVM.AccountName = "-";
            mainWindowVM.Balance = "-";
            mainWindowVM.LoggedIn = false;
            return;
        }

        mainWindowVM.AccountName = account.Symbol!;
        mainWindowVM.Balance = account.Credits.ToString()!;
        mainWindowVM.LoggedIn = true;
        retModel = account;
        ContinueButtonEnabled = true;
        StatusMessage = "Logged in";
        

    }
    #endregion
}
