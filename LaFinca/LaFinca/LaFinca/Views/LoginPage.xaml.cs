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
        IUser user;
        private List<IUser> users;
        public LoginPage()
        {
            users = Application.Current.Properties["Users"] as List<IUser>;
            user = new IUser();
            InitializeComponent();
            this.BindingContext = user;
        }

        public LoginPage(List<IUser> users,List<Models.MenuItem> items)
        {

        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            IUser foundUser = users.FirstOrDefault(child => child.username == user.username);

            if(foundUser != null)
            {
                if(foundUser.password == user.password)
                {
                    await Navigation.PushAsync(new DeleteUser());
                }
            }
            else
            {

            }

        }
    }
}