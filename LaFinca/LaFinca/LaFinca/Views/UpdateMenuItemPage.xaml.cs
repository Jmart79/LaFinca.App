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
    public partial class UpdateMenuItemPage : ContentPage
    {
        public Models.MenuItem ItemToUpdate;
        public UpdateMenuItemPage()
        {
            this.BindingContext = ItemToUpdate;
            InitializeComponent();
        }

        private void GetItem(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateClicked(object sender, EventArgs e)
        {

        }

        private void IsHouseFavoriteSwitch1_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}