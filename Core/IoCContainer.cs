using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Windows.Themes;
using SpaceTradersApp.MVVM.View;
using SpaceTradersApp.MVVM.ViewModel;
using System;
using System.Net.Http;

namespace SpaceTradersApp.Core;

/// <summary>
/// The IoC Container for the Application
/// Must be called on initalization of the application
/// </summary>
class IoCContainer
{
    #region singleton
    /// <summary>
    /// The private instance of the IoC Container
    /// </summary>
    private static readonly IoCContainer instance = new IoCContainer();
    
    /// <summary>
    /// The public instance of this IoCContainer
    /// </summary>
    public static IoCContainer Instance { get { return instance; } }
    #endregion

    #region public Variables
    /// <summary>
    /// The Application Host, of this application
    /// </summary>
    public static IHost AppHost { get; private set; }

    /// <summary>
    /// The available servives of this application
    /// </summary>
    public static IServiceProvider Services { get; set; }
    #endregion

    #region Views
    /// <summary>
    /// The MainWindow shorthand
    /// </summary>
    public static MainWindow MainWindow => Services.GetRequiredService<MainWindow>();
    #endregion

    #region Helpers
    /// <summary>
    /// Returns the Class that performs calls to the SpaceTraders API
    /// </summary>
    public static ISpaceTradersAPIHelper SpaceTradersAPI => Services.GetRequiredService<ISpaceTradersAPIHelper>();
    #endregion



    #region Constructors
    /// <summary>
    /// Explicit static constructor to tell C# compiler
    /// not to mark type as beforefieldinit
    ///
    /// </summary>
    static IoCContainer() 
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostcontext, services) =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<HomeView>(s => new HomeView(s.GetRequiredService<HomeViewModel>()));
                services.AddSingleton<ShipViewModel>();
                services.AddSingleton<ShipView>(s => new ShipView(s.GetRequiredService<ShipViewModel>()));

                services.AddHttpClient("SpaceTradersAPI", c =>
                {
                    c.BaseAddress = new Uri("https://api.spacetraders.io/v2/");
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                });
                services.AddSingleton<ISpaceTradersAPIHelper, SpaceTradersAPIHelper>();
            }).Build();

        Services = AppHost.Services;
    }

    private IoCContainer() {
    }
    #endregion
}
