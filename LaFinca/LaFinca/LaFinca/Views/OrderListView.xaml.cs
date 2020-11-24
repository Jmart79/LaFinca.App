using LaFinca.Models;
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
    public partial class OrderListView : ContentView
    {
        private List<Order> orders { get; set; }

        public OrderListView()
        {
            InitializeComponent();
        }

        public OrderListView(List<Order> orders)
        {
            this.orders = orders;
        }

        private void GenerateList()
        {

        }

    }
}