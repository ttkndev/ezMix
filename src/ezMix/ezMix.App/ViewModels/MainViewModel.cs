using ezMix.App.Assets.Core;
using ezMix.App.Models;
using ezMix.App.Services;
using System.Collections.ObjectModel;

namespace ezMix.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IExternalLinkService _externalLinkService;

        private BaseViewModel _currentView = null;
        private bool _isBusy = false;
        private string _overlayMessage = "Đang tải...";
        private string _subTitle = string.Empty;
        private bool _isHomeActive;
        private bool _isAboutActive;
        private bool _isDarkMode;

        public ObservableCollection<FooterLink> SocialItems { get; }
        public ObservableCollection<FooterLink> ContactItems { get; }

        public RelayCommand HomeCommand { get; }
        public RelayCommand AboutCommand { get; }
        public RelayCommand OpenFooterActionCommand { get; }
        public RelayCommand ToggleThemeCommand { get; }

        public MainViewModel(INavigationService navigationService, IExternalLinkService externalLinkService)
        {
            _navigationService = navigationService;
            _externalLinkService = externalLinkService;

            HomeCommand = new RelayCommand(_ => NavigateHome());
            AboutCommand = new RelayCommand(_ => NavigateAbout());
            OpenFooterActionCommand = new RelayCommand(ExecuteFooterAction);
            ToggleThemeCommand = new RelayCommand(_ => ToggleTheme());

            SocialItems = new ObservableCollection<FooterLink>
            {
                new FooterLink("Facebook", "https://www.facebook.com"),
                new FooterLink("Zalo", "https://zalo.me/g/rxncpe995"),
                new FooterLink("Youtube", "https://www.youtube.com"),
                new FooterLink("Website", "https://ttkndev.com")
            };

            ContactItems = new ObservableCollection<FooterLink>
            {
                new FooterLink("📞 0775 426 999", "tel:+84775426999"),
                new FooterLink("📧 ttkndev@gmail.com", "mailto:ttkndev@gmail.com")
            };

            NavigateHome();
        }

        public BaseViewModel CurrentView { get => _currentView; set => SetProperty(ref _currentView, value); }
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
        public string OverlayMessage { get => _overlayMessage; set => SetProperty(ref _overlayMessage, value); }
        public string SubTitle { get => _subTitle; set => SetProperty(ref _subTitle, value); }
        public bool IsHomeActive { get => _isHomeActive; set => SetProperty(ref _isHomeActive, value); }
        public bool IsAboutActive { get => _isAboutActive; set => SetProperty(ref _isAboutActive, value); }

        /// <summary>
        /// Cờ trạng thái theme hiện tại để đổi nội dung nút và dễ mở rộng lưu setting sau này.
        /// </summary>
        public bool IsDarkMode { get => _isDarkMode; set => SetProperty(ref _isDarkMode, value); }

        private void ExecuteFooterAction(object parameter)
        {
            _externalLinkService.Open(parameter as string ?? string.Empty);
        }

        private void NavigateHome()
        {
            _navigationService.NavigateHome();
            CurrentView = _navigationService.CurrentView;
            SubTitle = _navigationService.CurrentSubtitle;
            IsHomeActive = true;
            IsAboutActive = false;
        }

        private void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            App.ApplyTheme(IsDarkMode);
        }

        private void NavigateAbout()
        {
            _navigationService.NavigateAbout();
            CurrentView = _navigationService.CurrentView;
            SubTitle = _navigationService.CurrentSubtitle;
            IsHomeActive = false;
            IsAboutActive = true;
        }
    }
}
