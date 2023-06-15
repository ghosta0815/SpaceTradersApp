using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

public class HomeViewModel : ViewModelBase
{
    public IAsyncCommand ContinueGameCommand { get; set; }

    private string _bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZGVudGlmaWVyIjoiR0gwU1RBIiwidmVyc2lvbiI6InYyIiwicmVzZXRfZGF0ZSI6IjIwMjMtMDYtMTAiLCJpYXQiOjE2ODY0ODE3MDgsInN1YiI6ImFnZW50LXRva2VuIn0.tOtHGNU-i1E5ic7a6koLfWkTi5J5y8WmbHLqfd75RbrZZDCQTCAovmhOiEMovsglgebVSxrjViOPTpzVCpWFlKTb7sjlsvimqlUKqYeSozVszoc5WJDiBVNNgVkI-eO4tF6DAAdTQ93EZiFfuPsgWkLZshjOUbRw8988qdKaK6ZIoAqGPfTvTTasEqjhJARpIamWOChedgFrYxfxrAokB-loYwi-SJly8_yOutkBSxrxFgEOFGfbVvg3O9_Ly2T9X5CuiyNCBU283H2jXd5NMiFWEM4_zA_WfbpzndpNO3o3w0vXwE0PPFzkN9bARIPX8Axs7T8jmVIgtPuzif5CAw";

    public AccountModel? retModel;

    private bool _continueButtonEnabled = true;

    private string _loadingText = "";

    public string LoadingText
    {
        get { return _loadingText; }
        set { _loadingText = value; OnPropertyChanged(nameof(LoadingText)); }
    }


    public bool ContinueButtonEnabled
    {
        get { return _continueButtonEnabled; }
        set { _continueButtonEnabled = value; OnPropertyChanged(nameof(ContinueButtonEnabled)); }
    }


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

    public HomeViewModel()
    {
        ContinueGameCommand = new AsyncCommand(async () =>
        {
            await ContinueGameAsync();
        });
    }

    /// <summary>
    /// Method to continue the game, requires Bearer Token
    /// </summary>
    private async Task ContinueGameAsync()
    {
        ContinueButtonEnabled = false;
        LoadingText = "loading...";
        IoCContainer.SpaceTradersAPI.Token = BearerToken;
        AccountModel? account = await IoCContainer.SpaceTradersAPI.getAccountDataAsync();

        MainWindowViewModel mainWindowVM = IoCContainer.Services.GetRequiredService<MainWindowViewModel>();

        if (account == null)
        {
            ContinueButtonEnabled = true;
            LoadingText = "Invalid Token";
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
        LoadingText = "Logged in";
        

    }
}
