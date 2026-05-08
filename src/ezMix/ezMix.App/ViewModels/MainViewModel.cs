using ezMix.App.Assets.Core;
using ezMix.App.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ezMix.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView = null;
        private bool _isBusy = false;
        private string _overlayMessage = "Đang tải...";
        private string _subTitle = string.Empty;

        public ObservableCollection<FooterLink> FooterItems { get; }

        public RelayCommand HomeCommand { get; set; }
        public RelayCommand AboutCommand { get; set; }
        public RelayCommand OpenFooterActionCommand { get; set; }


        private readonly HomeViewModel _homeViewModel;
        private readonly AboutViewModel _aboutViewModel;

        public MainViewModel(
            HomeViewModel homeViewModel,
            AboutViewModel aboutViewModel)
        { 
            _homeViewModel = homeViewModel;
            _aboutViewModel = aboutViewModel;

            HomeCommand = new RelayCommand(_ => NavigateHome());
            AboutCommand = new RelayCommand(_ => NavigateContact());
            OpenFooterActionCommand = new RelayCommand(ExecuteFooterAction);

            FooterItems = new ObservableCollection<FooterLink>
            {
                new FooterLink("📘 Facebook", "https://www.facebook.com"),
                new FooterLink("💬 Zalo", "https://zalo.me/g/rxncpe995"),
                new FooterLink("🎬 Youtube", "https://www.youtube.com"),
                new FooterLink("🌐 Website", "https://ttkndev.com"),
                new FooterLink("📞 0775 426 999", "tel:+84775426999"),
                new FooterLink("📧 ttkndev@gmail.com", "mailto:ttkndev@gmail.com")
            };

            NavigateHome();
        }

        private static void ExecuteFooterAction(object parameter)
        {
            var actionValue = parameter as string;
            if (string.IsNullOrWhiteSpace(actionValue))
            {
                return;
            }

            var startInfo = new ProcessStartInfo(actionValue)
            {
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }

        public BaseViewModel CurrentView { get => _currentView; set => SetProperty(ref _currentView, value); }
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
        public string OverlayMessage { get => _overlayMessage; set => SetProperty(ref _overlayMessage, value); }
        public string SubTitle { get => _subTitle; set => SetProperty(ref _subTitle, value); }

        private void NavigateHome() => CurrentView = _homeViewModel;
        private void NavigateContact() => CurrentView = _aboutViewModel;
    }
}
