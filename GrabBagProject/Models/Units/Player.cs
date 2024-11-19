using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Pieces;

namespace GrabBagProject.Models.Units
{
    internal class Player : Unit
    {
        public Inventory Inventory = new Inventory(12);
        public Bag Bag = new (Path.Combine("Data", "pieces.json"), 5);
        public Player(int health)
        {
            Health = health;
            BuildUnit();
        }
    }
}
