using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Pieces;

namespace GrabBagProject.Models.Units
{
    internal class Player : Unit
    {
        public Inventory Inventory = new Inventory(12);
        public Bag Bag = new (Path.Combine("Data", "pieces.json"), 8);
        public Player(int health, string name = "Player")
        {
            Name = name;
            Health = health;
            BuildUnit();
        }
    }
}
