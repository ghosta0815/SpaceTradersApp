using System.Threading.Tasks;
using System;

namespace SpaceTradersApp.Core;

public class AsyncCommand : AsyncCommandBase
{
    private readonly Func<Task> _command;

    /// <summary>
    /// Creates an executable command
    /// </summary>
    /// <param name="command">The task to execute</param>
    public AsyncCommand(Func<Task> command)
    {
        _command = command;
    }

    /// <summary>
    /// Retruns true if the task can be executed
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    /// <summary>
    /// Executes a task asynchronously
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public override Task ExecuteAsync(object? parameter)
    {
        return _command();
    }
}
