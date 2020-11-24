using LaFinca.Models;
using LaFinca.Services;
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
    public partial class UpdateUserPage : ContentPage
    {
        public string UsernameToUpdate;
        public IUser UserToUpdate;
        public UpdateUserPage()
        {
            InitializeComponent();
        }

        public UpdateUserPage(bool IsManager)
        {
            InitializeComponent();
            if (IsManager)
            {
                UpdateRolePicker.IsVisible = true;
            }
        }

        public UpdateUserPage(IUser user)
        {
            this.BindingContext = user;
            UserToUpdate = user;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            //UpdateRolePicker.IsVisible = true;

        }

        private void UsernameInputed(object sender, EventArgs e)
        {
            UsernameToUpdate = UsernameToUpdateEntry.Text;
            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;

            UserToUpdate = users.FirstOrDefault(child => child.username == UsernameToUpdate);
            this.BindingContext = UserToUpdate;
        }

        private async void UpdateClicked(object sender, EventArgs e)
        {
            UserRestService service = new UserRestService();
            await service.UpdateData(UserToUpdate);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = e.ToString();
            string wtvr = sender.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;
            users.Remove(UserToUpdate);
            Navigation.PopAsync();
        }
    }
}