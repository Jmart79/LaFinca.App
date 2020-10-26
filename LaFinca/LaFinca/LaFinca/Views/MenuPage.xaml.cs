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
            _viewModel = new MenuViewModel();
            InitializeComponent();
            Title = "Category Selection";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { GenerateScrollView() }
            }; 
         }

        public MenuPage(List<Models.MenuItem> items)
        {
            _viewModel = new MenuViewModel();
        }

        

        private ScrollView GenerateScrollView()
        {
            ScrollView scrollView = new ScrollView
            {
                VerticleOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children = _viewModel.GenerateCells(),
                },
            };

            return scrollView;
        }

       
    }
}