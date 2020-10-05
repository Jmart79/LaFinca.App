using System.ComponentModel;
using Xamarin.Forms;
using LaFinca.ViewModels;

namespace LaFinca.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}