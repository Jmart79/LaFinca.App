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
            GenerateList();
            InitializeComponent();
        }

        private void GenerateList()
        {
            List<View> children = new List<View>();
            TapGestureRecognizer selectOrder_tap;
            Label orderLabel;

            int counter = 0;
            foreach(Order order in orders)
            {
                selectOrder_tap = new TapGestureRecognizer();

                string labelText = order.CustomerUsername + " " + order.OrderPlaced;

                orderLabel = new Label
                {
                    Text = labelText,
                    FontSize = 25,
                    TextColor = Color.FromHex("#134E6F"),
                    BackgroundColor = Color.FromHex("#1AC0C6"),
                    WidthRequest = 200,
                    HorizontalOptions = LayoutOptions.Center
                };

                selectOrder_tap.Tapped += (s, e) => 
                {
                    string selectedOrderUsername = (s as Label).Text.Split(' ')[0];
                    Order selectedOrder;
                    selectedOrder = orders.FirstOrDefault(child => child.CustomerUsername == selectedOrderUsername);
                
                    if(selectedOrder != null && counter == 0)
                    {
                  //      Navigation.PushAsync(new OrderDetailPage(selectedOrder));
                        counter++;
                    }
                };

                orderLabel.GestureRecognizers.Add(selectOrder_tap);
                children.Add(orderLabel);
            }

            StackLayout layout = new StackLayout();

            foreach(View view in children)
            {
                layout.Children.Add(view);
            }

            this.Content = layout;
        }

    }
}