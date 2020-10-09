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

        private void CreateClicked(object sender, EventArgs e)
        {            
            string isToggled = IsHouseFavoriteSwitch1.IsToggled.ToString().ToLower();
            if (isToggled == "true")
            {
                item.IsHouseFavorite = true;
            }

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value.ToString() == "true")
            {
                item.IsHouseFavorite = true;
            }
            
        }
    }
}