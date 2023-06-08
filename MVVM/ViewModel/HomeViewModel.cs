using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

public class HomeViewModel : ViewModelBase
{
    public IAsyncCommand ContinueGameCommand { get; set; }

    private string _bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZGVudGlmaWVyIjoiR0gwU1RBIiwidmVyc2lvbiI6InYyIiwicmVzZXRfZGF0ZSI6IjIwMjMtMDYtMDMiLCJpYXQiOjE2ODU5MDU0NDMsInN1YiI6ImFnZW50LXRva2VuIn0.eUCrl0IaaEGBTKZeuhwj2VG3lZYqCO9EPPy-vpOAO4EbmXC4tUx1ajyQC0DEneCedpF1zT2Np7YTi-WAQYnSkxlwIFKILdCq1ga2Vz_eIt8AQRLyBt6CakgHD-HjKI45kk9nGWgsYAXjdUSU3XHla1dSnKZEzFd5d-Dq-r6RoJaG_srXXv74fOf9Okw-ubpfee8WRrFieqx3CxGA4E-K1r99NeA-BhkqIbdqombgLaRWdfEGc3K7TLP9f0Cz8h2PFnfmpkYthUETpQ2qITk8ZCac5bliaiKVqkCVmy2AbxPq5uI82fh2Ek4jSCHlJWVC-uFbqxbZmU-Ig74vBUTJpg";

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

        if (account == null)
        {
            ContinueButtonEnabled = true;
            LoadingText = "Invalid Token";
            return;
        }

        IoCContainer.Services.GetRequiredService<MainWindowViewModel>().AccountName = account.Symbol!;
        IoCContainer.Services.GetRequiredService<MainWindowViewModel>().Balance = account.Credits.ToString()!;
        retModel = account;
        ContinueButtonEnabled = true;
        LoadingText = "";
    }
}
