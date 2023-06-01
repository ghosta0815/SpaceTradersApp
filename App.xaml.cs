using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Windows;
using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.View;
using SpaceTradersApp.MVVM.ViewModel;

namespace SpaceTradersApp;

public partial class App : Application
{
    private IHost AppHost { get; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostcontext, services) =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton <HomeView>(s => new HomeView(s.GetRequiredService<HomeViewModel>()));
                services.AddSingleton<ShipViewModel>();
                services.AddSingleton<ShipView>(s => new ShipView(s.GetRequiredService<ShipViewModel>()));
                
            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        IoCContainer.MyServiceProvider = AppHost.Services;
        IoCContainer.MyServiceProvider.GetRequiredService<MainWindow>().Show();
        
        base.OnStartup(e);  
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
