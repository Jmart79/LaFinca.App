﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaFinca.Models;
using LaFinca.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaFinca.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        IUser user;
        public LoginPage()
        {
            user = new IUser();
            InitializeComponent();
            this.BindingContext = user;
        }

        private void LoginClicked(object sender, EventArgs e)
        {

        }
    }
}