using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinca.Models;
using LaFinca.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaFinca.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _viewModel { get; set; }
        public LoginPage()
        {
            _viewModel = new LoginViewModel();
            this.BindingContext = _viewModel;
            InitializeComponent();

        }

        public LoginPage(List<IUser> users,List<Models.MenuItem> items)
        {

        }

        private  void LoginClicked(object sender, EventArgs e)
        {
            bool isLoginSuccessful = _viewModel.IsLoginSuccessful();

            if (isLoginSuccessful)
            {
                Application.Current.Properties["User"] = _viewModel.user;
                string role = _viewModel.user.role.ToLower();
                switch (role)
                {
                    case "customer":
                        Application.Current.MainPage = new CustomerHomePage(false);
                        break;
                    case "management":
                        //assign main page to the ManagementDetailPage
                        break;
                    default:
                        Application.Current.MainPage = new CustomerHomePage(false);
                        break;
                }
            }

            //_viewModel.NavigateLoginAttempt();
            //string username = _viewModel.user.username;
            //string password = _viewModel.user.password;
            //string authMsg = _viewModel.authenticationMessage;
            //UsernameLoginEntry.BindingContext = _viewModel.user.username;
            //PasswordLoginEntry.BindingContext = _viewModel.user.password;
            //AuthenticationLabel.BindingContext = _viewModel.authenticationMessage;
        }

        private void CancleClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}