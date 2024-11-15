using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Items.ItemModifiers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Units;

namespace GrabBagProject
{
    internal class Game
    {
        string? input;
        public static Controller ActiveController = new CombatController();
        public static Player Player = new Player(20);

        public Game()
        {
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything.");

            //TODO: TEST INVENTORY CODE
            Inventory inventory = Player.Inventory;
            inventory.AddItem(new Item().Build("Sword", "Basic sharp blade.", 4));
            inventory.AddItem(new Item().Build("Wooden Shield", "Weak wooden shield for blocking some damage.", 4));
            inventory.AddItem(new Item().Build("Healing Potion", "Simple means of regaining health.", 0,
                               new HealthModifier(10),
                               new ItemQuantity(4))
                );

            //TODO: TEST BAG CODE
            Bag bag = Player.Bag;
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
