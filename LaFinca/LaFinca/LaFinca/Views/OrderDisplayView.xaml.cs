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
    public partial class OrderDisplayView : ContentView
    {
        private List<Models.MenuItem> items { get;set; }
        public OrderDisplayView()
        {
            List<Models.MenuItem> items = Application.Current.Properties["Cart"] as List<Models.MenuItem>;
            GenerateList();
            InitializeComponent();
        }

        public OrderDisplayView(List<Models.MenuItem> items)
        {
            this.items = items;
            GenerateList();
            InitializeComponent();

        }

        private void GenerateList()
        {
            List<View> children = new List<View>();
            TapGestureRecognizer selectItem_tap;
            Label itemLabel;

            int counter = 0;

            foreach (Models.MenuItem item in items)
            {
                selectItem_tap = new TapGestureRecognizer();
                string labelText = $"{item.ItemName} {item.Cost}";

                itemLabel = new Label
                {
                    Text = labelText,
                    FontSize = 25,
                    TextColor = Color.FromHex("#134E6F"),
                    BackgroundColor = Color.FromHex("#1AC0C6"),
                    WidthRequest = 200,
                    HorizontalOptions = LayoutOptions.Center
                };

                selectItem_tap.Tapped += (s, e) =>
                {
                    string selectedItemName = (s as Label).Text.Split(' ')[0];
                    Models.MenuItem selectedItem;
                    selectedItem = items.FirstOrDefault(child => child.ItemName == selectedItemName);

                    if (selectedItem != null)
                    {
                        //Navigate to item detail page
                        counter++;
                    }
                };

                itemLabel.GestureRecognizers.Add(selectItem_tap);
                children.Add(itemLabel);
            }

            StackLayout layout = new StackLayout();

            foreach (View view in children)
            {
                layout.Children.Add(view);
            }

            this.Content = layout;
        }
    }
}