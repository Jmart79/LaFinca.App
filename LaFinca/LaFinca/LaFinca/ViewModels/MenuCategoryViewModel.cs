﻿using LaFinca.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace LaFinca.ViewModels
{
    class MenuCategoryViewModel : BaseViewModel
    {
        public string category { get; set; }
        public CategoryDisplayView CurrentItem { get; set; }
        public List<Models.MenuItem> CategoryItems { get; set; }
        private int _itemIndex { get; set; }

        public MenuCategoryViewModel()
        {
            this.category = "New Bruncherias";
            this.CategoryItems = GetItems();
            this._itemIndex = 0;
            GenerateCategoryDisplayView(CategoryItems.ElementAt(_itemIndex));
        }
        public MenuCategoryViewModel(string Category)
        {
            this.category = Category;
            this.CategoryItems = GetItems();
            this._itemIndex = 0;
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

        public Command FavorItem()
        {
            return null;
        }

        public Command OrderItem()
        {
            return null;
        }

       
    }
}
