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
    public partial class CustomerHomePage : TabbedPage
    {
        private bool _isGuest { get; set; }
        public CustomerHomePage(bool isGuest)
        {
            this._isGuest = isGuest;

            NavigationPage orderPage;
            NavigationPage menuPage;
            NavigationPage settingsPage;

            if (_isGuest)
            {
                menuPage = new NavigationPage(new MenuCategoryDetailPage());
                menuPage.Title = "Menu";
                settingsPage = new NavigationPage(new LoginPage());
                settingsPage.Title = "Login";


                Children.Add(menuPage);
                Children.Add(settingsPage);
            }
            else
            {
                orderPage = new NavigationPage(new OrderPage());
                orderPage.Title = "Order";
                menuPage = new NavigationPage(new MenuCategoryDetailPage());
                menuPage.Title = "Menu";
                settingsPage = new NavigationPage(new UpdateUserPage());
                settingsPage.Title = "Account Settings";
                Children.Add(orderPage);
                Children.Add(menuPage);
                Children.Add(settingsPage);
            }


            InitializeComponent();
        }        



    }
}