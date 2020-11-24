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
    public partial class ViewUsersPage : ContentPage
    {
        public ViewUsersPage()
        {
            InitializeComponent();

            List<IUser> users = Application.Current.Properties["Users"] as List<IUser>;
            List<string> usernames = new List<string>();

            foreach(IUser user in users)
            {
                usernames.Add(user.username);
            }

            this.Content = new UsersListView(usernames,users);

        }
    }
}