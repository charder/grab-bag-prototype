using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Units;

namespace GrabBagProject
{
    internal class Game
    {
        string? input;
        Controller activeController = new ShopController();
        public static Player Player = new Player(20);

        public Game()
        {
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything.");
            Inventory inventory = Player.Inventory;
            inventory.AddItem(new Item().Build("Sword", "Basic sharp blade.", 4));
            inventory.AddItem(new Item().Build("Wooden Shield", "Weak wooden shield for blocking some damage.", 4));
        }
        public void Loop()
        {
            if (!activeController.Completed)
            {
                input = Console.ReadLine();
                string[] inputs = string.IsNullOrEmpty(input) ? [] : (input.ToLower()).Split(' ');
                activeController.ParseInput(inputs);
            }
        }
    }
}
