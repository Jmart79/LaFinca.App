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
    public partial class CategoryDisplayView : ContentView
    {
        private MenuCategoryViewModel _viewModel { get; set; }
        private Models.MenuItem _item { get; set; }
        private string _category { get; set; }
        public CategoryDisplayView()
        {
            this._viewModel = new MenuCategoryViewModel();
            this._item = _viewModel.GetNextItem();
            this.BindingContext = _item;
            InitializeComponent();
        }
        public CategoryDisplayView(Models.MenuItem item)
        {
            this._item = item;
            this.BindingContext = _item;
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //add to favors list
            //use mysql to store local user data
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Button orderBtn = sender as Button;
            string btnText = orderBtn.Text.ToLower();

            List<Models.MenuItem> cart = Application.Current.Properties["Cart"] as List<Models.MenuItem>;

            switch (btnText)
            {
                case "order":
                    cart.Add(_item);
                    orderBtn.Text = "Remove";
                    break;
                case "remove":
                    cart.Remove(_item);
                    orderBtn.Text = "Order";
                    break;
                    default:
                        break;
            }
            Application.Current.Properties["Cart"] = cart;
            //add to order
        }
    }
}