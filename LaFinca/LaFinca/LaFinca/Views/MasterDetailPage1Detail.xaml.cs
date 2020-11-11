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
    public partial class MasterDetailPage1Detail : ContentPage
    {
        public MasterDetailPage1Detail()
        {
            InitializeComponent();
        }

        public MasterDetailPage1Detail(NavigationPage page)
        {
            
        }
    }
}