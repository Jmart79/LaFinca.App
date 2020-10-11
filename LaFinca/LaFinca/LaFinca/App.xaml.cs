using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaFinca.Services;
using LaFinca.Views;
using System.Collections.Generic;
using LaFinca.Models;
using System.Threading.Tasks;

namespace LaFinca
{
    public partial class App : Application
    {
        public static  List<IUser> _users;
        public static List<Models.MenuItem> _items;
        public  App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(CreateHomePage());
        }

        private  HomePage CreateHomePage()
        {
            UserRestService userService = new UserRestService();
            ItemRestService itemService = new ItemRestService();
            
                SetData(userService, itemService);

            List<Models.MenuItem> items = Application.Current.Properties["Items"] as List<Models.MenuItem>;

            return new HomePage();

        }

        private async void SetData(UserRestService userservice, ItemRestService itemService)
        {
            List<IUser> usersTemp = await GetUsers(userservice);
            List<Models.MenuItem> itemsTemp = await GetItems(itemService);

            Application.Current.Properties["Users"] = usersTemp;
            Application.Current.Properties["Items"] = itemsTemp;
        }

        private async Task<List<IUser>> GetUsers(UserRestService service)
        {
            return await service.RefreshData();
        }

        private async Task<List<Models.MenuItem>> GetItems(ItemRestService swervice) { return await swervice.RefreshData(); }
    
        protected async override void OnStart()
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
