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
    public partial class HomePage : ContentPage
    {
        public List<IUser> _users;
        public List<Models.MenuItem> _items;

        public HomePage()
        {
            InitializeComponent();
            
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void OnRegisterClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());
        }

        async void OnContinueClicked(object sender, EventArgs e)
        {
            NavigationPage temp = new NavigationPage();
            IUser user    = new IUser();
            Application.Current.Properties["User"] = user;
            //await Navigation.PushAsync(new CustomerHomePage(true));
            await Navigation.PushAsync(new ViewUsersPage());
           // await Navigation.PushAsync(new MasterDetailPage1Master());
        }
    }
}