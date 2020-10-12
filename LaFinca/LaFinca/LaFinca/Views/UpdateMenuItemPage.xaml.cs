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

        private void IsHouseFavoriteSwitch1_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string VariableToChange = VariableToUpdatePicker.SelectedItem.ToString().ToLower();

            switch (VariableToChange)
            {
                case "description":
                    GenerateEntry("Description");
                    break;

                case "cost":
                    break;
                case "category":
                    break;
                case "IsAvailable":
                    break;
                case "IsHouseFavorite":
                    break;
                case "ItemName":
                    break;
                default:
                    break;
            }

        }

        private void GenerateEntry(string placeholder)
        {
            Entry entry = new Entry();

            entry.Placeholder = placeholder;
            //set binding context to a new user
            //set event handler to a generalized event hanlder to handle all entries that might be created for updates.
            //
        }

        private void ItemToUpdate_Completed(object sender, EventArgs e)
        {
             ItemToUpdateName = ItemToUpdate.Text;
        }
    }
}