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
    public partial class NewUserPage : ContentPage
    {
        private List<IUser> users;
        public IUser user;
        public NewUserPage()
        {
            user = new IUser();
            InitializeComponent();
            this.BindingContext = user;
            this.users = (List<IUser>)Application.Current.Properties["Users"];
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            IUser foundUser = users.FirstOrDefault(child => child.username == user.username);
            string password = user.password;
            bool isPasswordValid = password != null && password != "" && password.Trim() != "";
            if (foundUser == null && isPasswordValid)
            {
                UserRestService userService = new UserRestService();
                Application.Current.Properties["Users"] = await userService.AddData(user);

                // await Navigation.PushAsync(new LoginPage());

                MenuCategoryDetailPage categoryDetailPage = new MenuCategoryDetailPage();

                 var page = (Page)Activator.CreateInstance(categoryDetailPage.GetType());
                page.Title = categoryDetailPage.Title;

                var masterDetailParentPage = this.Parent.Parent;

                MasterDetailPage1 parentPage = masterDetailParentPage as MasterDetailPage1;
                NavigationPage detailPage = new NavigationPage(categoryDetailPage);
                NavigationPage.SetHasNavigationBar(detailPage, true);

                detailPage.BackgroundColor = Color.FromHex("#7A2323");
                detailPage.BarBackgroundColor = Color.FromHex("#7A2323");
                parentPage.Detail = detailPage;
                parentPage.IsPresented = false; 

            }
            else
            {

            }

        }
    }
}