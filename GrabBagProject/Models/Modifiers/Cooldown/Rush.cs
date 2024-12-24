using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Cooldown
{
    /// <summary>
    /// Rush lowers the active cooldowns of Weapons.
    /// </summary>
    internal class Rush : Swift
    {
        public Rush(int value) : base(value) { }

        public override string ToString()
        {
            return $"\nRush {Value} - Reduce all active Weapon cooldowns by {Value}.";
        }

        #region INTERFACES

        public override void OnUse()
        {
            Item? item = (ModifierHolder as Item);
            if (item is null) return;

            // Lower any active cooldowns of Weapons in the Player's Inventory.
            List<Item> allItems = Game.Player.Inventory.GetAllItems();
            allItems.ForEach(i =>
            {
                if (i is Weapon)
                    LowerItemCooldown(item, i);
            });
        }

        #endregion
    }
}


