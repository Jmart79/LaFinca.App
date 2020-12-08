using LaFinca.Models;
using LaFinca.ViewModels;
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
    public partial class OrderDetailPage : ContentPage
    {
        public OrderViewModel viewModel { get; set; }
        public OrderDetailPage()
        {
            InitializeComponent();
            viewModel = new OrderViewModel();
            this.BindingContext = viewModel.currentOrder;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OrderItemsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}