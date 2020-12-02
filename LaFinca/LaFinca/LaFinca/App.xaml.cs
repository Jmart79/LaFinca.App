using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaFinca.Services;
using LaFinca.Views;
using System.Collections.Generic;
using LaFinca.Models;
using System.Threading.Tasks;
[assembly: ExportFont("Merriweather-BlackItalic.ttf", Alias ="TitleFont")]
[assembly: ExportFont("Cinzel-SemiBold.ttf", Alias = "TitleFont2")]
[assembly: ExportFont("Vollkorn-MediumItalic.ttf", Alias = "TitleFont2")]
namespace LaFinca
{
    public partial class App : Application
    {
        public static  List<IUser> _users;
        public static List<Models.MenuItem> _items;
        public  App()
        {
            //DependencyService.Get<IStatusBar>().HideStatusBar();
            InitializeComponent();

            UserRestService userService = new UserRestService();
            ItemRestService itemService = new ItemRestService();

            SetData(userService, itemService);
            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;
            MainPage = new NavigationPage(new HomePage());
        }

       

        private async void SetData(UserRestService userservice, ItemRestService itemService)
        {
            List<IUser> usersTemp = await userservice.RefreshData();
            List<Models.MenuItem> itemsTemp = await itemService.RefreshData();

            Application.Current.Properties["Users"] = usersTemp;
            Application.Current.Properties["Items"] = itemsTemp;
        }

      
        protected  override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
