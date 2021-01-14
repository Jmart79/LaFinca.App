using LaFinca.Models;
using LaFinca.Services;
using LaFinca.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms; 

namespace LaFinca.ViewModels
{
    class MenuCategoryViewModel : BaseViewModel
    {
        public string category { get; set; }
        public CategoryDisplayView CurrentItem { get; set; }
        public List<Models.MenuItem> CategoryItems { get; set; }
        public Models.MenuItem CurrentMenuItem { get; set; }
        private int _itemIndex { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public string FavorButtonText { get; set; }
        public string OrderButtonText { get; set; }
        public ICommand FavorItemCommand { get; private set; }

        public MenuCategoryViewModel()
        {
            this.category = "New Bruncherias";
            this.CategoryItems = GetItems();
            this._itemIndex = 0;
            CurrentMenuItem = CategoryItems.ElementAt(_itemIndex);
            MenuItemName = CurrentMenuItem.ItemName;
            MenuItemDescription = CurrentMenuItem.Description;
            FavorItemCommand = new Command(FavorItem,IsFavoredButtonEnabled);
            GenerateCategoryDisplayView(CategoryItems.ElementAt(_itemIndex));
        }
        public MenuCategoryViewModel(string Category)
        {
            this.category = Category;
            this.CategoryItems = GetItems();
            this._itemIndex = 0;
            CurrentMenuItem = CategoryItems.ElementAt(_itemIndex);
            MenuItemName = CurrentMenuItem.ItemName;
            MenuItemDescription = CurrentMenuItem.Description;
            GenerateCategoryDisplayView(CategoryItems.ElementAt(_itemIndex));
        }

        public void SetItems()
        {
            CategoryItems = GetItems();
            _itemIndex = 0;
            GenerateCategoryDisplayView(CategoryItems.ElementAt(_itemIndex));
        }

        public List<Models.MenuItem> GetItems()
        {
            List<Models.MenuItem> items = Application.Current.Properties["Items"] as List<Models.MenuItem>;
            List<Models.MenuItem> sortedItems = items.FindAll(menuItem => menuItem.Category == this.category);
            return sortedItems;
        }

        public Models.MenuItem GetNextItem()
        {
            Models.MenuItem item;
            int count = CategoryItems.Count;

            if (_itemIndex == CategoryItems.Count) 
            {
                _itemIndex = 0;
                item = CategoryItems.ElementAt(_itemIndex);
            } else if ( CategoryItems.Count <= 1)
            {
                item = CategoryItems.ElementAt(_itemIndex);
            }
            else
            {
                item = CategoryItems.ElementAt(_itemIndex++);
            }             
            GenerateCategoryDisplayView(item);
            return item;
        }
        public Models.MenuItem GetPreviousItem()
        {
            Models.MenuItem item;
            
            if (_itemIndex < 0)
            {
                _itemIndex = CategoryItems.Count-1;
                item = CategoryItems.ElementAt(_itemIndex);
            }else if(_itemIndex == 0)
            {
                item = CategoryItems.ElementAt(_itemIndex);
                _itemIndex = CategoryItems.Count - 1;
            }
            else
            {
                 item = CategoryItems.ElementAt(_itemIndex--);
            }
            GenerateCategoryDisplayView(item);
            return item;
        } 
        
        public void GenerateCategoryDisplayView(Models.MenuItem item)
        {
            CategoryDisplayView categoryDisplay = new CategoryDisplayView(item);
            CurrentItem = categoryDisplay;
        }

        public Command SwipeCommand()
        {
            return null;
        }

        public bool IsDeleteButtonEnabled(object sender)
        {
            IUser user = Application.Current.Properties["User"] as IUser;

            bool isManagement =  user.role.ToLower() == "management";
            return isManagement;
        }

        public bool IsFavoredButtonEnabled()
        {
            IUser user = Application.Current.Properties["User"] as IUser;

            bool isCustomer =  user.role.ToLower() == "customer";
            return isCustomer;
        }

        void FavorItem()
        {

        }

        void UnFavorItem()
        {

        }
   

        public Command OrderItem()
        {
            return null;
        }

       
    }
}
