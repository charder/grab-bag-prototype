using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Cooldown
{
    /// <summary>
    /// Item/Enemy starts on Cooldown.
    /// </summary>
    internal class Sluggish : Modifier, IOnCombatStart
    {
        public Sluggish() { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nSluggish - Starts combat on cooldown.";
            return value;
        }

        #region INTERFACES

        public void OnCombatStart()
        {
            Enemy? enemy = (ModifierHolder as Enemy);
            if (enemy != null)
            {
                EnemyCooldown? cooldown = (enemy.Modifiers.Find(m => m is EnemyCooldown)) as EnemyCooldown;
                if (cooldown != null)
                    cooldown.GoOnCooldown();
                return;
            }

            Item? item = (ModifierHolder as Item);
            if (item != null)
            {
                CombatCost? cost = (item.Modifiers.Find(m => m is CombatCost)) as CombatCost;
                if (cost != null)
                    cost.GoOnCooldown();
                return;
            }
        }

        #endregion
    }
}


