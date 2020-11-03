using LaFinca.Models;
using LaFinca.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace LaFinca.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public List<string> Categories;
        private static string SelectedCategory;
        public List<Models.MenuItem> items;

        public MenuViewModel()
        {
            GenerateCategories();
        }

        private void GenerateCategories()
        {
            Categories = new List<string>()
            {
                "Family Brunch Platters",
                "Starters",
                "Pan",
                "Omelet",
                "Pancakes",
                "Chilaquiles",
                "French Toast",
                "Crepas",
                "Waffles",
                "New Bruncheria",
                "De La Granja",
                "Breakfast Tacos",
                "Lunch Menu",
                "Light Options",
                "Drinks",
                "Espersso Bar",
                "Menudo Y Barbacoa",
                "Desserts and Sweets"
            };
        }

        
        public void ChangeSelectedCategory(string newCategory)
        {
            SelectedCategory = newCategory;
        }

        public string GetCategory()
        {
            return SelectedCategory;
        }

        public List<CategoryCell> GenerateCells()
        {
            List<CategoryCell> cells = new List<CategoryCell>();

            CategoryCell cell;
            foreach (string category in Categories) 
            {
                cell = new CategoryCell(category, this);
                cells.Add(cell);
            }

            return cells;
        }

        public List<Models.MenuItem> GetItems()
        {
            List<Models.MenuItem> MenuItems = Application.Current.Properties["Items"] as List<Models.MenuItem>;
            List<Models.MenuItem> SortedItems = MenuItems.Where(child => child.Category == SelectedCategory) as List<Models.MenuItem>;

            return SortedItems;
        }

        public void CategorySelected()
        {
            //TODO: navigate to to the CategoryDetail page with appropriate data being passed through
            
           // Navigation.PushAsync(new MenuCategoryDetailPage(SelectedCategory));
        }
        
        public List<MenuItemDetailPage> GenerateDetailPages()
        {
            List<Models.MenuItem> sortedItems = GetItems();
            List<MenuItemDetailPage> detailPages = new List<MenuItemDetailPage>();
            MenuItemDetailPage detailPage;
            foreach(Models.MenuItem item in sortedItems)
            {
                detailPage = new MenuItemDetailPage();
                detailPages.Add(detailPage);
            }
            return detailPages;
        }

      

    }  

    public class CategoryCell : ViewCell
    {
        private MenuViewModel _viewModel;
        private readonly string _categoryName;

        public CategoryCell()
        {

        }

        public CategoryCell(string categoryName, MenuViewModel viewModel) 
        {
            _viewModel = viewModel;
            _categoryName = categoryName;
            BindingContext = viewModel;

            Button CategoryButton = new Button();
            CategoryButton.Text = categoryName;
            CategoryButton.BackgroundColor = Color.BurlyWood;
            CategoryButton.VerticalOptions = LayoutOptions.Center;

            CategoryButton.Clicked += (sender, args) => _viewModel.CategorySelected();
           
        }
    }

}
