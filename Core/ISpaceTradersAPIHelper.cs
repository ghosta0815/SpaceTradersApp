using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core
{
    public interface ISpaceTradersAPIHelper
    {
        Task<AccountModel?> getAccountDataAsync();
    }
}