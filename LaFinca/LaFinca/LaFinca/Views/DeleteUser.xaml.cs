using LaFinca.Models;
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
    public partial class DeleteUser : ContentPage
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private bool DoesUserExist()
        {
            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;
            IUser foundUser = users.FirstOrDefault(child => child.username == DeleteUsernameInput.Text);

            return foundUser != null;
        }

        private async void DeleteUserClicked(object sender, EventArgs e)
        {
            if (DoesUserExist())
            {
                UserRestService service = new UserRestService();
               Application.Current.Properties["Users"] = await service.Delete(DeleteUsernameInput.Text);
            }
        }
    }
}