
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFinca.Models
{
    public class MenuItem
    {
        public string Id { get; set; }
        
        public string ItemName { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsHouseFavorite { get; set; }

        public MenuItem() { }

        public MenuItem(string name, string description,string category, double cost, bool available = true, bool houseFavorite = false)
        {
            this.ItemName = name;
            this.Description = description;
            this.Category = category;
            this.Cost = cost;
            this.IsAvailable = available;
            this.IsHouseFavorite = houseFavorite;

            this.Description += $" {Cost}";
        }
    }
}
