using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Windows.Themes;
using SpaceTradersApp.MVVM.View;
using SpaceTradersApp.MVVM.ViewModel;
using System;
using System.Configuration;
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

    /// <summary>
    /// The FleetView shorthand
    /// </summary>
    public static FleetView FleetView => Services.GetRequiredService<FleetView>();

    /// <summary>
    /// The sector View Shorthand
    /// </summary>
    public static SectorView SectorView => Services.GetRequiredService<SectorView>();
    #endregion

    #region ViewModels
    /// <summary>
    /// The MainWindowModel shorthand
    /// </summary>
    public static MainWindowViewModel MainWindowModel => Services.GetRequiredService<MainWindowViewModel>();

    /// <summary>
    /// The FleetViewModel shorthand
    /// </summary>
    public static FleetViewModel FleetViewModel => Services.GetRequiredService<FleetViewModel>();

    /// <summary>
    /// The sector ViewModel Shorthand
    /// </summary>
    public static SectorViewModel SectorViewModel => Services.GetRequiredService<SectorViewModel>();
    #endregion

    #region Helpers
    /// <summary>
    /// Returns the Class that performs calls to the SpaceTraders API
    /// </summary>
    public static ISpaceTradersAPIHelper SpaceTradersAPI => Services.GetRequiredService<ISpaceTradersAPIHelper>();

    /// <summary>
    /// Returns the Class that stores and writes the Bearer Tokens
    /// </summary>
    public static ITokenFileHandler TokenFileHandler => Services.GetRequiredService<ITokenFileHandler>();
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
                services.AddSingleton<StartScreenViewModel>();
                services.AddSingleton<StartScreenView>(s => new StartScreenView(s.GetRequiredService<StartScreenViewModel>()));
                services.AddSingleton<FleetViewModel>();
                services.AddSingleton<FleetView>(s => new FleetView(s.GetRequiredService<FleetViewModel>()));
                services.AddSingleton<SectorViewModel>();
                services.AddSingleton<SectorView>(s => new SectorView(s.GetRequiredService<SectorViewModel>()));

                services.AddHttpClient("SpaceTradersAPI", c =>
                {
                    c.BaseAddress = new Uri("https://api.spacetraders.io/v2/");
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                });
                services.AddSingleton<ISpaceTradersAPIHelper, SpaceTradersAPIHelper>();
                services.AddSingleton<ITokenFileHandler, TokenFileHandler>();
            }).Build();

        Services = AppHost.Services;
    }

    private IoCContainer() {
    }
    #endregion
}
