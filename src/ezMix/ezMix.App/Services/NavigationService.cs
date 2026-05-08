using ezMix.App.Assets.Core;
using ezMix.App.ViewModels;

namespace ezMix.App.Services
{
    public class NavigationService : INavigationService
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly AboutViewModel _aboutViewModel;

        public NavigationService(HomeViewModel homeViewModel, AboutViewModel aboutViewModel)
        {
            _homeViewModel = homeViewModel;
            _aboutViewModel = aboutViewModel;
            NavigateHome();
        }

        public BaseViewModel CurrentView { get; private set; } = null;
        public string CurrentSubtitle { get; private set; } = string.Empty;

        public void NavigateHome()
        {
            CurrentView = _homeViewModel;
            CurrentSubtitle = "Trang tổng quan giải pháp";
        }

        public void NavigateAbout()
        {
            CurrentView = _aboutViewModel;
            CurrentSubtitle = "Thông tin liên hệ & năng lực";
        }
    }
}
