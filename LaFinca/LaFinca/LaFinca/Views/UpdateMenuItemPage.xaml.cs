﻿using LaFinca.Services;
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
        public Models.MenuItem UpdatedItem { get; set; }
        public UpdateMenuItemPage()
        {
            InitializeComponent();
        }

        

        private async void UpdateClicked(object sender, EventArgs e)
        {
            ItemRestService service = new ItemRestService();

             await service.UpdateData(UpdatedItem);

        }

        private void ItemToUpdate_Completed(object sender, EventArgs e)
        {
             ItemToUpdateName = ItemToUpdate.Text;
            UpdatedItem = FindItem();
            if (UpdatedItem != null)
            {
                this.BindingContext = UpdatedItem;
            }

        }

        private Models.MenuItem FindItem()
        {
            List<Models.MenuItem> items = Application.Current.Properties["Items"] as List<Models.MenuItem>;
            Models.MenuItem foundItem = items.FirstOrDefault(child => child.ItemName == ItemToUpdateName);
            return foundItem;
        }
    }
}