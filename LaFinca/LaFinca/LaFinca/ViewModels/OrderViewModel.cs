using LaFinca.Models;
using LaFinca.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaFinca.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public List<Models.MenuItem> cart { get; set; }
        public List<string> itemNames { get; set; }
        public Order currentOrder { get; set; }

        public OrderViewModel()
        {
            if (Application.Current.Properties.ContainsKey("Cart"))
            {
                this.cart = Application.Current.Properties["Cart"] as List<Models.MenuItem>;
                IUser user = Application.Current.Properties["User"] as IUser;
                Order order = new Order(user.username, user.username, DateTime.Now.ToString(), "pending", cart);
                order.Items = cart;
                itemNames = new List<string>();

                foreach (Models.MenuItem item in cart)
                {
                    itemNames.Add(item.ItemName);
                }
            }
        }

    }
}
