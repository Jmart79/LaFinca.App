using LaFinca.Services;
using LaFinca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaFinca.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private List<IUser> users;
        public IUser user;
        public RegisterPage()
        {
            user = new IUser();
            InitializeComponent();
            this.BindingContext = user;
            this.users = (List<IUser>)Application.Current.Properties["Users"];
        }

        public RegisterPage(List<IUser> users, List<Models.MenuItem> items)
        {
            user = new IUser();
            this.users = users;
            InitializeComponent();
        }     

        private async void RegisterClicked(object sender, EventArgs e)
        {
            IUser foundUser = users.FirstOrDefault(child => child.username == user.username);

            if(foundUser == null)
            {
                UserRestService userService = new UserRestService();
                Application.Current.Properties["Users"] = await userService.AddData(user);

                await Navigation.PushAsync(new LoginPage());

            }
            else
            {
                
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }
    }
}