using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal class Shop : ItemHolder
    {
        public Shop(int capacity) : base(capacity) { }

        public override string ToString()
        {
            string response = "Shop - To learn more about an item, type 's #' where # is the number associated with it:";
            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];
                if (item != null)
                    response += $"\n{i}. {item.Name}";
            }
            return response;
        }
    }
}
