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
        private readonly string _category { get; }
        public MenuCategoryDetailPage()
        {
            _category = "Pancakes";
            
        }

        public MenuCategoryDetailPage(string Category)
        {
            _category = Category;
            InitializeComponent();
        }

        private Button GenerateButton()
        {
            Button btn = new Button();
            btn.Text = _category;
            return btn;
        }
    }
}