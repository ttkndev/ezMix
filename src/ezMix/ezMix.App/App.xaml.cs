using ezMix.App.Services;
using ezMix.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ezMix.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Microsoft.Extensions.DependencyInjection

        public static IServiceProvider Services { get; private set; } = null;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IExternalLinkService, ExternalLinkService>();
            services.AddSingleton<MainViewModel>();

            Services = services.BuildServiceProvider();

            var mainViewModel = Services.GetRequiredService<MainViewModel>();
            var mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
