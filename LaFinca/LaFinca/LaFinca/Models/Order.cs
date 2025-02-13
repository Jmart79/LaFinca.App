﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFinca.Models
{
    public class Order
    {
        public string Id { get; set; }
        public double Cost { get; set; }
        public double FinalCost { get; set; }
        public string OrderId { get; set; }
        public string CustomerUsername { get; set; }        
        public string OrderPlaced { get; set; }
        public string OrderReady { get; set; } = null;
        public string State { get; set; }
        public List<Models.MenuItem> Items { get; set; }
        public List<string> ItemsName { get; set; }

        public Order() { }

        public Order(string id, string username, string orderPlaced, string state, List<Models.MenuItem> names)
        {
            this.OrderId = id;
            this.CustomerUsername = username;
            this.OrderPlaced = orderPlaced;
            this.State = state;
            
            foreach(Models.MenuItem item in names)
            {
                Cost += item.Cost;
            }
            this.FinalCost = (Cost * .0825) + Cost;
            this.Items = names;
        }

    }
}
