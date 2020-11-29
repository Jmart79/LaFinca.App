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
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);

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
                NavigationPage.SetHasNavigationBar(settingsPage, false);
                Children.Add(menuPage);
                Children.Add(settingsPage);
            }
            else
            {
                orderPage = new NavigationPage(new OrderDetailPage());
                orderPage.Title = "Order";
                NavigationPage.SetHasNavigationBar(orderPage, false);
                menuPage = new NavigationPage(new MenuCategoryDetailPage());
                menuPage.Title = "Menu";
                settingsPage = new NavigationPage(new UpdateUserPage());
                settingsPage.Title = "Account Settings";
                NavigationPage.SetHasNavigationBar(settingsPage, false);
                Children.Add(orderPage);
                Children.Add(menuPage);
                Children.Add(settingsPage);

                CurrentPage = menuPage;
            }


            InitializeComponent();
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            CustomerHomePage page = sender as CustomerHomePage;
            NavigationPage currentPage = (NavigationPage)page.CurrentPage;
            if(currentPage.Title == "Order")
            {
                page.CurrentPage = new NavigationPage(new OrderDetailPage());
            }
            string str = sender.ToString();
            Type type = sender.GetType();
        }
    }
}