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
    public partial class MenuCategoryDetailPage : ContentPage
    {
        private  string _category { get; }
        private MenuCategoryViewModel _viewModel { get; set; }
        public MenuCategoryDetailPage()
        {
            _category = "Pancakes";
            _viewModel = new MenuCategoryViewModel(_category);
            BindingContext = _viewModel;
            //CategoryDisplayView categoryDisplayView = _viewModel.CurrentItem;
            //this.CategoryDisplayStackLayout.Children.Add(_viewModel.CurrentItem) ;
            InitializeComponent();

        }

        public MenuCategoryDetailPage(string category)
        {
            _category = category;
            _viewModel = new MenuCategoryViewModel(_category);
            BindingContext = _viewModel;
            this.CategoryDisplayStackLayout.Children.Add(_viewModel.CurrentItem);
            InitializeComponent();
        }

        public void SetCategoryDisplayView()
        {
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            SwipeDirection swipeDirection = e.Direction;

            switch (swipeDirection)
            {
                case SwipeDirection.Left:
                    Models.MenuItem nextitem = _viewModel.GetNextItem();
                    _viewModel.GenerateCategoryDisplayView(nextitem);
                    MenuItemDispalyView.Content = _viewModel.CurrentItem;

                    //           Content = new StackLayout { Children = _viewModel.GetNextMenuItemDetailPage() };
                    break;
                case SwipeDirection.Right:
                    Models.MenuItem previousitem = _viewModel.GetPreviousItem();
                    _viewModel.GenerateCategoryDisplayView(previousitem);
                    MenuItemDispalyView.Content = _viewModel.CurrentItem;
                    break;
            }
        }


        private void CategorySelectionPicker_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string category = CategorySelectionPicker.SelectedItem as string;
            _viewModel.category = category;
            _viewModel.SetItems();
            MenuItemDispalyView.Content = _viewModel.CurrentItem;
        }
    }
}