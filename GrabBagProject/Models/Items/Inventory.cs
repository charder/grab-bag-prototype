using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal class Inventory : IInteractable
    {
        Item[] items;
        public Inventory(int capacity)
        {
            items = new Item[capacity];
        }

        public string GetDescription()
        {
            return items.Aggregate("Inventory:", (inventory, next) => inventory += "\n" + next.GetDescription());
        }
    }
}
