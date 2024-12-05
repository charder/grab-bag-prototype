using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Modifiers.Attack;
using GrabBagProject.Models.Modifiers.Block;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;

namespace GrabBagProject
{
    internal class Game : StatContainer
    {
        string? input;
        public static Controller ActiveController = new ShopController();
        public static Player Player = new Player(20);
        // Singleton Instance.
        public static Game Instance;

        public Game()
        {
            Instance = this;
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything.");

            //TODO: TEST INVENTORY CODE
            Inventory inventory = Player.Inventory;
            inventory.AddItem(new Weapon().Build("Sword", "Basic sharp blade.", 4,
                              new Attack(6),
                              new CombatCost(1))
                );
            inventory.AddItem(new Shield().Build("Wooden Shield", "Weak wooden shield for blocking some damage.", 4,
                              new Block(5),
                              new CombatCost(1, ("Guard", 2)))
                );
            inventory.AddItem(new Item().Build("Healing Potion", "Simple means of regaining health.", 0,
                               new ItemQuantity(4))
                );

            //TODO: TEST BAG CODE
            Bag bag = Player.Bag;
            List<PieceInstance>? pieces = JsonBuilder.FromFile<List<PieceInstance>>(Path.Combine(@"Data", "bag.json"));
            pieces?.ForEach(p => bag.AddPieceToFullBag( p.Name, p.Quantity));

            ActiveController = new CombatController();
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
