using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Utilities;

namespace GrabBagProject.Controllers
{
    internal class ShopController : Controller
    {
        protected Shop _shop = new Shop(999);
        public override void Constructor()
        {
            _shop.AddItem(new Item().Build("Iron Shield", "A much stronger shield, able to block more damage.", 10));
            _shop.AddItem(new Item().Build("Bow & Arrow", "A ranged option, able to strike foes from a distance.", 6));
            Command command = new Command(
                "Shop",
                "List current shop inventory.",
                ["shop", "s"]
                );
            AddCommand(command, Shop);
            command = new Command(
                "Buy",
                "Purchase an item from the shop.",
                ["buy","b"]
                );
            AddCommand(command, Buy);
            command = new Command(
                "Sell",
                "Sell an item in your inventory.",
                ["sell"]
                );
            AddCommand(command, Sell);
            command = new Command(
                "Leave Shop",
                "Finish shopping and leave the shop.",
                ["leave", "l"]
                );
            AddCommand(command, Leave);
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

        private void Buy(string[] args)
        {
            if (args.Length == 1)
                Console.WriteLine("To buy an item, specify # of item after 'buy'. Ex: 'buy 1'.");
            else
            {
                if (int.TryParse(args[1], out int value))
                {
                    Item? item = _shop.GetItem(value);
                    if (item != null)
                    {
                        Inventory inventory = Game.Player.Inventory;
                        int cost = item.Value;
                        if (!inventory.HasSpace)
                            Console.WriteLine("Inventory is full! Sell items to make space.");
                        else if (inventory.Gold < cost)
                            Console.WriteLine($"Not enough gold to purchase {item.Name}! Need {cost}, have {inventory.Gold}.");
                        else
                        {
                            inventory.Gold -= cost;
                            _shop.RemoveItem(item);
                            inventory.AddItem(item);
                            Console.WriteLine($"Purchased {item.Name} for {cost} gold.");
                        }
                    }
                    else
                        Console.WriteLine($"Invalid purchase - '{value}' is not a valid option. Type 'shop' for a list of available items.");
                }
                else
                {
                    Console.WriteLine("Invalid purchase - must enter valid # after 'buy'. Ex: 'buy 1'.");
                }
            }
        }

        private void Sell(string[] args)
        {
            if (args.Length == 1)
                Console.WriteLine("To sell an item, specify # of item after 'sell'. Ex: 'sell 1'.");
            else
            {
                if (int.TryParse(args[1], out int value))
                {
                    Inventory inventory = Game.Player.Inventory;
                    Item? item = inventory.GetItem(value);
                    if (item != null)
                    {
                        if (!_shop.CanSell)
                            Console.WriteLine("Cannot sell to this shop!");
                        else
                        {
                            inventory.RemoveItem(item);
                            int sellGold = item.Value / 2;
                            Console.WriteLine($"Sold {item.Name} to shop and gained {sellGold} gold.");
                            inventory.Gold += sellGold;
                            _shop.AddItem(item);
                        }
                    }
                    else
                        Console.WriteLine($"Invalid sell - '{value}' is not a valid option. Type 'shop' for a list of available items.");
                }
                else
                {
                    Console.WriteLine("Invalid sell - must enter valid # after 'sell'. Ex: 'sell 1'.");
                }
            }
        }

        private void Leave(string[] args)
        {

        }
    }
}
