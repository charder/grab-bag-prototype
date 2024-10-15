using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool InInventory { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            string value = $"{Name} - {Description}\n" +
                (InInventory ? $"Sell Value: {Value / 2}" : $"Cost: {Value}");
            return value;
        }
    }
}
