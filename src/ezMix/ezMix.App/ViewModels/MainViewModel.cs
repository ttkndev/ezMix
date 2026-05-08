using ezMix.App.Assets.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ezMix.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView = null;
        private bool _isBusy = false;
        private string _overlayMessage = "Đang tải...";

        public RelayCommand HomeCommand { get; set; }
        public RelayCommand ContactCommand { get; set; }

        private readonly HomeViewModel _homeViewModel;
        private readonly ContactViewModel _contactViewModel;

        public MainViewModel(
            HomeViewModel homeViewModel,
            ContactViewModel contactViewModel)
        { 
            _homeViewModel = homeViewModel;
            _contactViewModel = contactViewModel;

            HomeCommand = new RelayCommand(_ => NavigateHome());
            ContactCommand = new RelayCommand(_ => NavigateContact());
        }

        public BaseViewModel CurrentView { get => _currentView; set => SetProperty(ref _currentView, value); }
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
        public string OverlayMessage { get => _overlayMessage; set => SetProperty(ref _overlayMessage, value); }

        private void NavigateHome() => CurrentView = _homeViewModel;
        private void NavigateContact() => CurrentView = _contactViewModel;
    }
}
