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
            IUser currentUser = Application.Current.Properties["User"] as IUser; 
            if(currentUser.role.ToLower() == "management")
            {
                this.UpdateRolePicker.IsVisible = true;
                this.DeleteUserButton.IsVisible = true;
                this.DeleteUserButton.WidthRequest = 225;                
                NavigationPage.SetHasNavigationBar(this, true);
            }
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
            UsernameToUpdate = user.username;
            InitializeComponent();
            IUser currentUser = Application.Current.Properties["User"] as IUser;

            if(currentUser.role.ToLower() == "management")
            {
                UpdateRolePicker.IsVisible = true;
                DeleteUserButton.IsVisible = true;
            }
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

            IUser currentUser = Application.Current.Properties["User"] as IUser;

            if (currentUser.role.ToLower() == "management")
            {
                ViewUsersPage viewUsers = new ViewUsersPage();
                var page = (Page)Activator.CreateInstance(viewUsers.GetType());
                page.Title = viewUsers.Title;
                var parentOfParent = this.Parent.Parent.Parent;
                MasterDetailPage1 parentPage = (parentOfParent as MasterDetailPage1);
                NavigationPage detailPage = new NavigationPage(viewUsers);
                detailPage.BarBackgroundColor = Color.FromHex("#7A2323");
                parentPage.Detail = detailPage;
                parentPage.IsPresented = false;
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string updatedRole = (UpdateRolePicker.SelectedItem as string).ToLower();
            this.UserToUpdate.role = updatedRole;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;
            users.Remove(UserToUpdate);
            UserRestService userService = new UserRestService();
            string username = UsernameToUpdate;
            await userService.Delete(username);
            Application.Current.Properties["Users"] = users;

            IUser currentUser = Application.Current.Properties["User"] as IUser;

            if(currentUser.role.ToLower() == "management")
            {
                ViewUsersPage viewUsers = new ViewUsersPage();
                var page = (Page)Activator.CreateInstance(viewUsers.GetType());
                page.Title = viewUsers.Title;
                var parentOfParent = this.Parent.Parent;
                MasterDetailPage1 parentPage = (parentOfParent as MasterDetailPage1);
                NavigationPage detailPage = new NavigationPage(viewUsers);
                detailPage.BarBackgroundColor = Color.FromHex("#7A2323");
                parentPage.Detail = detailPage;
                parentPage.IsPresented = false;
            }

            //Navigation.PopAsync();
        }
    }
}