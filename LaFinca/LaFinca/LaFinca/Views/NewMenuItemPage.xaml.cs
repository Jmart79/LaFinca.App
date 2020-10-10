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
            string isToggled = IsHouseFavoriteSwitch1.IsToggled.ToString().ToLower();
            ItemRestService service = new ItemRestService();
            Models.MenuItem foundItem = items.FirstOrDefault(child => child.ItemName == item.ItemName);
            if (isToggled == "true")
            {
                item.IsHouseFavorite = true;
            }

            if(foundItem == null)
            {
                Application.Current.Properties["Items"] = await service.AddData(item);
            }
            

        }

        
    }
}