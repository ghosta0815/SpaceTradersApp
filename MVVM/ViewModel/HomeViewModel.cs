using SpaceTradersApp.Core;
using Microsoft.Extensions.DependencyInjection;

namespace SpaceTradersApp.MVVM.ViewModel;

public class HomeViewModel : ObservableObject
{
    public RelayCommand ContinueGameCommand { get; set; }

    private string? _bearerToken;

    public string? BearerToken
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
        ContinueGameCommand = new RelayCommand(o =>
        {
            ContinueGame();
        });
    }

    /// <summary>
    /// Method to continue the game, requires Bearer Token
    /// </summary>
    public void ContinueGame()
    {
        
    }
}
