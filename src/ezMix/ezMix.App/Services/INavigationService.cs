using ezMix.App.Assets.Core;

namespace ezMix.App.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }
        string CurrentSubtitle { get; }
        void NavigateHome();
        void NavigateAbout();
    }
}
