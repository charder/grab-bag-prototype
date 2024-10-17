using GrabBagProject.Models.Items.ItemHolders;

namespace GrabBagProject.Models.Units
{
    internal class Player : Unit
    {
        public Inventory Inventory = new Inventory(12);
        public Player(int health)
        {
            Health = health;
            BuildUnit();
        }
    }
}
