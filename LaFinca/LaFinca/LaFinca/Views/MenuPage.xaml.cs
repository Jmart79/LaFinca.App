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
    public partial class MenuPage : ContentPage
    {
        MenuViewModel _viewModel;
        public MenuPage()
        {
            Title = "Category Selection";
            InitializeComponent();
            CategorySelectionPicker.SelectedIndex = 10;
         }

        public MenuPage(List<Models.MenuItem> items)
        {
            _viewModel = new MenuViewModel();
        }

    }
}