using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Items.ItemModifiers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Units;
using GrabBagProject.Models.Values.Integer;
using GrabBagProject.Models.Values.Stats;
using GrabBagProject.Utilities;

namespace GrabBagProject
{
    internal class Game : StatContainer
    {
        string? input;
        public static Controller ActiveController = new CombatController();
        public static Player Player = new Player(20);
        // Singleton Instance.
        public static Game Instance;

        public Game()
        {
            Instance = this;
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything.");

            //TODO: TEST INVENTORY CODE
            Inventory inventory = Player.Inventory;
            inventory.AddItem(new Item().Build("Sword", "Basic sharp blade.", 4,
                              new CombatCost(1, new Piece("Power", 2)))
                );
            inventory.AddItem(new Item().Build("Wooden Shield", "Weak wooden shield for blocking some damage.", 4));
            inventory.AddItem(new Item().Build("Healing Potion", "Simple means of regaining health.", 0,
                               new HealthModifier(new FlatInteger(10)),
                               new ItemQuantity(new FlatInteger(4)))
                );

            //TODO: TEST BAG CODE
            Bag bag = Player.Bag;
            List<PieceInstance>? pieces = JsonBuilder.FromFile<List<PieceInstance>>(Path.Combine(@"Data", "bag.json"));
            pieces?.ForEach(p => bag.AddPiece(p.Piece, p.Quantity));
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
