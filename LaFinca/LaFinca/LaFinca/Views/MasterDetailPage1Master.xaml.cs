using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaFinca.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView lv;
        protected MasterDetailPage1MasterViewModel viewModel;
        public MasterDetailPage1Master()
        {
            InitializeComponent();

            viewModel = new MasterDetailPage1MasterViewModel();
            this.BindingContext = viewModel;
            lv = MenuItemsListView;
            //lv = new ListView {
            //    ItemTemplate = new DataTemplate(() => {
            //        var grid = new Grid { Padding = new Thickness(5, 10) };
            //        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
            //        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            //        var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
            //        label.SetBinding(Label.TextProperty, "Title");

            //        grid.Children.Add(label, 1, 0);
            //        return new ViewCell { View = grid };
            //    }),
            //    SeparatorVisibility = SeparatorVisibility.None,              
            //};
            //Title = "Management Navigation";
            //Content = new StackLayout
            //{
            //    Children = { lv}
            //};

        }

        public class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MasterMenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MasterMenuItem>(new[]
                {
                    new MasterDetailPage1MasterMenuItem { Id = 0, Title = "Orders", TargetType= typeof(OrderPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 1, Title = "Users",TargetType= typeof(ViewUsersPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 2, Title = "Update User",TargetType=typeof(UpdateUserPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 3, Title = "Menu",TargetType=typeof(MenuCategoryDetailPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 4, Title = "Add Item",TargetType=typeof(NewMenuItemPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 5, Title = "Update Item",TargetType=typeof(UpdateMenuItemPage) },
                    new MasterDetailPage1MasterMenuItem { Id = 6, Title = "Add User",TargetType=typeof(NewUserPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void MenuItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterDetailPage1MasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            MasterDetailPage1 parentPage = (this.Parent as MasterDetailPage1);
            parentPage.Detail = new NavigationPage(page);
            parentPage.IsPresented = false;

         //   parentPage.lv.SelectedItem = null;
        }
    }
}