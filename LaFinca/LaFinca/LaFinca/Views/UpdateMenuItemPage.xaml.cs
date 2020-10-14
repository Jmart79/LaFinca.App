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
        public static string ItemToUpdateName { get; set; }
        public UpdateMenuItemPage()
        {
            InitializeComponent();
        }

        

        private void UpdateClicked(object sender, EventArgs e)
        {

        }

        private void ItemToUpdate_Completed(object sender, EventArgs e)
        {
             ItemToUpdateName = ItemToUpdate.Text;
        }
    }
}