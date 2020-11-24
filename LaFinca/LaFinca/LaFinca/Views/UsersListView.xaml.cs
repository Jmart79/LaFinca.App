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
            List<View> children = new List<View>();
            Label usernameLabel;
            TapGestureRecognizer selectUser_Tap = new TapGestureRecognizer();

            int counter = 0;
            foreach(string username in Usernames)
            {
                usernameLabel = new Label
                {
                    Text = username,
                    FontSize = 25,
                    TextColor = Color.FromHex("#134E6F"),
                    BackgroundColor = Color.FromHex("#1AC0C6"),
                    WidthRequest = 175,
                    HorizontalOptions = LayoutOptions.Center
                };

                selectUser_Tap.Tapped += (s, e) =>
                {
                    IUser selectedUser;
                    selectedUser = Users.FirstOrDefault(user => user.username == (s as Label).Text);

                    if(selectedUser != null && counter == 0)
                    {
                        Navigation.PushAsync(new UpdateUserPage(selectedUser));
                        counter++;
                    }
                };
                usernameLabel.GestureRecognizers.Add(selectUser_Tap);
                children.Add(usernameLabel);                
            }

            StackLayout layout = new StackLayout();

            foreach(View view in children)
            {
                layout.Children.Add(view);
            }

            this.Content = layout;
        }

    }
}