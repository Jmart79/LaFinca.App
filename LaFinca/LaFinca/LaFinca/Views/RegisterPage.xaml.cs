using LaFinca.Services;
using LaFinca.Models;
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
    public partial class RegisterPage : ContentPage
    {
        public ItemRestService service = new ItemRestService();
        public IUser user;
        public RegisterPage()
        {
            user = new IUser();
            InitializeComponent();
            this.BindingContext = user;
          //  GetData();

        }

        private async void GetData()
        {
            List<Models.MenuItem> items = await service.RefreshData();

            if(items != null)
            {
                foreach (Models.MenuItem item in items)
                {
                    string name = item.ItemName;
                }
            }
            

        }

        private void RegisterClicked(object sender, EventArgs e)
        {
        }
    }
}