using LaFinca.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaFinca.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Command ContinueCommand { get; }

        public HomeViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            ContinueCommand = new Command(OnContinueClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        private async void OnContinueClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MenuPage)}");
        }

    }
}
