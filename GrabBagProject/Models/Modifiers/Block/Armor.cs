using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Block
{
    /// <summary>
    /// Armor is the base value that blocks incoming damage.
    /// </summary>
    internal class Armor : Modifier, IOnTurnStart
    {
        public int Value { get; set; }
        public Armor(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nArmor {Value} - Gain {Value} armor at the start of each turn.";
            return value;
        }

        #region INTERFACES

        public void OnTurnStart()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            int armor = 0;

            Unit? target = ModifierHolder as Player;
            if (target != null)
            {
                armor = target.GainArmor(Value);
                return;
            }

            target = ModifierHolder as Enemy;
            if (target != null)
            {
                armor = target.GainArmor(Value);
            }
        }

        #endregion
    }
}


