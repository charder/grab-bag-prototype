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
    /// Uplink lowers the total cooldowns of 'Autonomous' Items in combat.
    /// </summary>
    internal class Uplink : Modifier, IOnCombatStart
    {
        public int Value { get; set; }
        public Uplink(int value) 
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nUplink {Value} - Reduce all 'Autonomous' Item cooldowns by {Value} in combat.";
            return value;
        }

        protected virtual void LowerItemCooldown(Item usedItem, Item item)
        {
            // Only Autonomous Items are affected.
            if (!item.Name.Contains("Autonomous")) return;
            
            CombatCost? combatCost = Utils.FindModifier<CombatCost>(item.Modifiers);
            if (combatCost is not null)
            {
                combatCost.Cooldown = Math.Max(1, combatCost.Cooldown - Value);
            }
        }

        #region INTERFACES

        public virtual void OnCombatStart()
        {
            Item? item = (ModifierHolder as Item);
            if (item is null) return;


            List<Item> allItems = Game.Player.Inventory.GetAllItems();
            allItems.ForEach(i =>
            {
                LowerItemCooldown(item, i);
            });
        }

        #endregion
    }
}


