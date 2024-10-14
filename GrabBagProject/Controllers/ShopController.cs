using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Controllers
{
    internal class ShopController : Controller
    {
        protected Shop _shop = new Shop(12);
        public override void Constructor()
        {
            _shop.AddItem(new Item("Iron Shield", "A much stronger shield, able to block more damage."));
            _shop.AddItem(new Item("Bow & Arrow", "A ranged option, able to strike foes from a distance."));
            Command command = new Command(
                "Shop",
                "List current inventory shop inventory.",
                ["shop", "s"]
                );
            AddCommand(command, Shop);
            base.Constructor();
        }

        public override void ParseInput(params string[] args)
        {
            base.ParseInput(args);
        }

        private void Shop(string[] args)
        {
            if (args.Length == 1)
                Console.WriteLine(_shop.ToString());
            else
            {
                if (int.TryParse(args[1], out int value))
                {
                    Item? item = _shop.GetItem(value);
                    if (item != null)
                        Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
