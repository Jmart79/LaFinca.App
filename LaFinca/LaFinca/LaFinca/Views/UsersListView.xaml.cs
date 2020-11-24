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
    public partial class UsersListView : ContentView
    {
        private List<String> Usernames { get; set; }
        private List<IUser> Users { get; set; }
        public UsersListView()
        {
            InitializeComponent();
        }

        public UsersListView(List<String> Usernames,List<IUser> Users)
        {
            this.Usernames = Usernames;
            this.Users = Users;
            GenerateList();
        }

        private void GenerateList()
        {
            Label usernameLabel;
            TapGestureRecognizer selectUser_Tap = new TapGestureRecognizer();
            IUser selectedUser;

            foreach(string username in Usernames)
            {
                usernameLabel = new Label
                {
                    Text = username,
                    FontSize = 75,
                    TextColor = Color.FromHex("#134E6F"),
                    BackgroundColor = Color.FromHex("#1AC0C6"),
                    WidthRequest = 175,
                    HorizontalOptions = LayoutOptions.Center
                };

                selectUser_Tap.Tapped += (s, e) =>
                {
                    selectedUser = Users.FirstOrDefault(user => user.username == username);

                    if(selectedUser != null)
                    {
                        Navigation.PushAsync(new UpdateUserPage(selectedUser));
                    }
                };
                usernameLabel.GestureRecognizers.Add(selectUser_Tap);
               // children.Add(usernameLabel);
                this.UsersListLayout.Children.Add(usernameLabel);
            }


        }

    }
}