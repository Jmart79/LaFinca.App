using LaFinca.Services;
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
    public partial class DeleteMenuItem : ContentPage
    {
        public DeleteMenuItem()
        {
            InitializeComponent();
        }

        private bool DoesItemExist()
        {
            List<Models.MenuItem> items = Application.Current.Properties["Items"] as List<Models.MenuItem>;

            Models.MenuItem foundItem = items.FirstOrDefault(item => item.ItemName == DeleteItemInput.Text);

            return foundItem != null;
        }

        private async void DeleteItemClicked(object sender, EventArgs e)
        {
            if (DoesItemExist())
            {
                ItemRestService service = new ItemRestService();

                Application.Current.Properties["Items"] =  await service.DeleteData(DeleteItemInput.Text);
            }

        }
    }
}