using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SpaceTradersApp.MVVM.Model;

namespace SpaceTradersApp.MVVM.ViewModel;

public class HomeViewModel : ObservableObject
{
    public IAsyncCommand ContinueGameCommand { get; set; }

    private string _bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZGVudGlmaWVyIjoiR0gwU1RBIiwidmVyc2lvbiI6InYyIiwicmVzZXRfZGF0ZSI6IjIwMjMtMDYtMDMiLCJpYXQiOjE2ODU5MDU0NDMsInN1YiI6ImFnZW50LXRva2VuIn0.eUCrl0IaaEGBTKZeuhwj2VG3lZYqCO9EPPy-vpOAO4EbmXC4tUx1ajyQC0DEneCedpF1zT2Np7YTi-WAQYnSkxlwIFKILdCq1ga2Vz_eIt8AQRLyBt6CakgHD-HjKI45kk9nGWgsYAXjdUSU3XHla1dSnKZEzFd5d-Dq-r6RoJaG_srXXv74fOf9Okw-ubpfee8WRrFieqx3CxGA4E-K1r99NeA-BhkqIbdqombgLaRWdfEGc3K7TLP9f0Cz8h2PFnfmpkYthUETpQ2qITk8ZCac5bliaiKVqkCVmy2AbxPq5uI82fh2Ek4jSCHlJWVC-uFbqxbZmU-Ig74vBUTJpg";

    public AccountModel retModel;

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
            IoCContainer.SpaceTradersAPI.Token = BearerToken;
            AccountModelResponse response = await IoCContainer.SpaceTradersAPI.getAccountDataAsync();
        });
    }

    /// <summary>
    /// Method to continue the game, requires Bearer Token
    /// </summary>
    public void ContinueGame()
    {
        
    }
}
