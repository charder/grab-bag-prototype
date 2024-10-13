using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal class Inventory
    {
        List<Item> items;
        private int _capacity;
        public Inventory(int capacity)
        {
            _capacity = capacity;
            items = new List<Item>();
        }

        public override string ToString()
        {
            string response = "Inventory - To learn more about an item, type the number associated with it:";
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                if (item != null)
                    response += $"\n{i}. {item.Name}";
            }
            return response;
        }

        public Item? GetItem(int index)
        {
            return index >= items.Count ? null : items[index];
        }

        public bool AddItem(Item item)
        {
            if (items.Count >= _capacity)
                return false;
            items.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            return items.Remove(item);
        }
    }
}
