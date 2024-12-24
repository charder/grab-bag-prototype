using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Modifiers.Offensive;
using GrabBagProject.Models.Modifiers.Block;
using GrabBagProject.Models.Modifiers.Cooldown;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;

namespace GrabBagProject
{
    internal class Game : StatContainer
    {
        string? input;
        public static Controller ActiveController;
        public static Player Player;
        // Singleton Instance.
        public static Game Instance;

        public Game()
        {
            Instance = this;
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything.");

            //TODO: TEST INVENTORY CODE
            Player = new Player(20);
            Inventory inventory = Player.Inventory;
            inventory.AddItem(new Weapon().Build("Blade", "Basic sharp blade.", 4,
                              new Attack(6),
                              new CombatCost(1, ("Power", 1))
                ));
            inventory.AddItem(new Weapon().Build("Blade", "Basic sharp blade.", 4,
                              new Attack(6),
                              new CombatCost(1, ("Power", 1))
                ));


            inventory.AddItem(new Helmet().Build("Red Visor", "All you see is red.", 8,
                              new Rush(1),
                              new CombatCost(1, ("Energy", 2))
                ));
            inventory.AddItem(new Armor().Build("Core Armor", "Padded for protection.", 6,
                              new Armored(4),
                              new Block(4),
                              new CombatCost(0, ("Guard", 1))
                ));
            inventory.AddItem(new Boots().Build("Core Boots", "Keeps you on your feet.", 4,
                  new Armored(2)
                ));
            inventory.AddItem(new Item().Build("Red Chip", "Plug it in for Power.", 10,
                              new Reload(2),
                              new Locked(),
                              new CombatCost(2, ("Utility", 1), ("Energy", 1))
                ));

            //TODO: TEST BAG CODE
            Bag bag = Player.Bag;
            List<PieceInstance>? pieces = JsonBuilder.FromFile<List<PieceInstance>>(Path.Combine(@"Data", "bag.json"));
            pieces?.ForEach(p => bag.AddPieceToFullBag( p.Name, p.Quantity));

            ActiveController = new ShopController();
        }

        public void Loop()
        {
            if (!ActiveController.Completed)
            {
                input = Console.ReadLine();
                string[] inputs = string.IsNullOrEmpty(input) ? [] : (input.ToLower()).Split(' ');
                ActiveController.ParseInput(inputs);
            }
        }
    }
}
