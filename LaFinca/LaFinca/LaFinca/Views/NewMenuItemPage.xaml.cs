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
    public partial class NewMenuItemPage : ContentPage
    {
        public Models.MenuItem item;
        
        public NewMenuItemPage()
        {
            item = new Models.MenuItem();
            InitializeComponent();
            this.BindingContext = item;

        }

        private async void CreateClicked(object sender, EventArgs e)
        {
            List<Models.MenuItem> items = Application.Current.Properties["Items"] as List<Models.MenuItem>;
            bool isToggled = IsHouseFavoriteSwitch1.IsToggled;
            ItemRestService service = new ItemRestService();
            Models.MenuItem foundItem = items.FirstOrDefault(child => child.ItemName == item.ItemName);
            if (isToggled)
            {
                item.IsHouseFavorite = true;
            }

            if(foundItem == null)
            {
                Application.Current.Properties["Items"] = await service.AddData(item);
            }
            MenuCategoryDetailPage categoryDetailPage = new MenuCategoryDetailPage();

            var page = (Page)Activator.CreateInstance(categoryDetailPage.GetType());
            page.Title = categoryDetailPage.Title;

            var masterDetailParentPage = this.Parent.Parent;

            MasterDetailPage1 parentPage = masterDetailParentPage as MasterDetailPage1;
            NavigationPage detailPage = new NavigationPage(categoryDetailPage);
            NavigationPage.SetHasNavigationBar(detailPage, true);

            detailPage.BackgroundColor = Color.FromHex("#7A2323");
            parentPage.Detail = detailPage;
            parentPage.IsPresented = false;
            



           // await Navigation.PushAsync(new DeleteMenuItem());
        }

        
    }
}