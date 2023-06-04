using System.Windows;
using SpaceTradersApp.Core;

namespace SpaceTradersApp;

/// <summary>
/// Main Class of the application
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Constructor for the application
    /// </summary>
    public App()
    {
    }
    /// <summary>
    /// OnStartup method that is called when starting the application
    /// Initializes the IocContainer
    /// </summary>
    /// <param name="e"></param>
    protected override async void OnStartup(StartupEventArgs e)
    {
        await IoCContainer.AppHost!.StartAsync();

        IoCContainer.MainWindow.Show();
        
        base.OnStartup(e);  
    }

    /// <summary>
    /// On Exit of the application, this method is called
    /// Stops the IoCContainer
    /// </summary>
    /// <param name="e"></param>
    protected override async void OnExit(ExitEventArgs e)
    {
        await IoCContainer.AppHost!.StopAsync();
        base.OnExit(e);
    }
}
