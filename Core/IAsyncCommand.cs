using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceTradersApp.Core;

public interface IAsyncCommand : ICommand
{
    Task ExecuteAsync(object? parameter);
}
