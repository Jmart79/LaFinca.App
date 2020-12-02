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
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            string pause = "Pause";
            InitializeComponent();
            MasterPage.lv.ItemTapped += ListView_ItemSelected;
           
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterDetailPage1MasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            NavigationPage navPage = new NavigationPage(page);
            navPage.BarBackgroundColor = Color.FromHex("#7A2323");
            Detail = navPage;
            IsPresented = false;

            MasterPage.lv.SelectedItem = null;
        }
    }
}