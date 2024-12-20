﻿using GrabBagProject.Actions;
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
    /// Swift lowers the active cooldowns of Items.
    /// </summary>
    internal class Swift : Modifier, IOnUse
    {
        public int Value { get; set; }
        public Swift(int value) 
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nSwift {Value} - Reduce all active Item cooldowns by {Value}.";
            return value;
        }

        protected virtual void LowerItemCooldown(Item usedItem, Item item)
        {
            CombatCost? combatCost = Utils.FindModifier<CombatCost>(item.Modifiers);
            if (combatCost is not null)
            {
                int cdReduction = combatCost.LowerCooldown(Value);
                if (cdReduction > 0)
                    Console.WriteLine($"{usedItem.Name} reduces cooldown of {item.Name} by {cdReduction}.");
            }
        }

        #region INTERFACES

        public virtual void OnUse()
        {
            Item? item = (ModifierHolder as Item);
            if (item is null) return;

            // Lower any active cooldowns of Items in the Player's Inventory.
            List<Item> allItems = Game.Player.Inventory.GetAllItems();
            allItems.ForEach(i =>
            {
                LowerItemCooldown(item, i);
            });
        }

        #endregion
    }
}


