using System;
using System.Collections.Generic;
using LaFinca.ViewModels;
using LaFinca.Views;
using Xamarin.Forms;

namespace LaFinca
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
