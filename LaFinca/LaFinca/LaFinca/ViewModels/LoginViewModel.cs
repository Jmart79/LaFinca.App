using LaFinca.Models;
using LaFinca.Views;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace LaFinca.ViewModels
{
    public class LoginViewModel
    {
        public IUser user { get; set; }
        public string authenticationMessage { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        private IEnumerable<IUser> users { get; set; }

        public LoginViewModel()
        {
            users = Application.Current.Properties["Users"] as List<IUser>;
            user = new IUser();
        }

        public IUser FindUser()
        {
            IUser foundUser = users.Where(child => child.username == username).FirstOrDefault();
            return foundUser;
        }

        public bool IsLoginSuccessful()
        {
            bool isLoginSuccessful = false;
            IUser foundUser = FindUser();
            if (foundUser != null)
            {
                if (foundUser.password == password)
                {
                    isLoginSuccessful = true;
                    user = foundUser;
                }
                
            }
            return isLoginSuccessful;
        }

        public void NavigateLoginAttempt()
        {
            if (IsLoginSuccessful())
            {
                
            }
            else
            {
                user = new IUser();
                authenticationMessage = "Login Failed";
            }
            
        }

    }
}
