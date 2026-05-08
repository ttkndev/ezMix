using ezMix.App.Services;
using ezMix.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;

namespace ezMix.App
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null;

        /// <summary>
        /// Đổi theme runtime bằng cách thay thế dictionary LightTheme/DarkTheme.
        /// Cách này giúp toàn bộ DynamicResource cập nhật ngay mà không phải reload Window.
        /// </summary>
        public static void ApplyTheme(bool isDarkMode)
        {
            var existingTheme = Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && (d.Source.OriginalString.Contains("ThemeLight.xaml") || d.Source.OriginalString.Contains("ThemeDark.xaml")));

            if (existingTheme != null)
            {
                Current.Resources.MergedDictionaries.Remove(existingTheme);
            }

            var themePath = isDarkMode ? "Assets/Styles/ThemeDark.xaml" : "Assets/Styles/ThemeLight.xaml";
            var mergedDictionaries = Current.Resources.MergedDictionaries;
            var insertIndex = Math.Min(3, mergedDictionaries.Count);
            mergedDictionaries.Insert(insertIndex, new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) });
        }

        protected override void OnStartup(StartupEventArgs e)
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
