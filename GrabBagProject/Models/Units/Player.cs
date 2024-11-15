﻿using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Pieces;

namespace GrabBagProject.Models.Units
{
    internal class Player : Unit
    {
        public Inventory Inventory = new Inventory(12);
        public Bag Bag = new ();
        public Player(int health)
        {
            Health = health;
            BuildUnit();
        }
    }
}
