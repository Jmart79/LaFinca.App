﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaFinca.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemDetailPage : ContentPage
    {
        private Models.MenuItem Item { get; set; }
        public MenuItemDetailPage()
        {
            Item = new Models.MenuItem();
            this.BindingContext = Item;
            InitializeComponent();
        }

        public MenuItemDetailPage(Models.MenuItem item)
        {
            this.Item = item;
            this.BindingContext = Item;
            InitializeComponent();
        }
    }
}