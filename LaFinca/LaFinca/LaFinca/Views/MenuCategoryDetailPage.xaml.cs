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
        public MenuCategoryDetailPage()
        {
            _category = "Pancakes";
            BindingContext = _category;
            InitializeComponent();

        }

        public MenuCategoryDetailPage(string category)
        {
            _category = category;
        }
    }
}