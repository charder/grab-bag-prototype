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

namespace GrabBagProject.Models.Modifiers.Block
{
    /// <summary>
    /// Gain Armor each turn.
    /// </summary>
    internal class Armored : Modifier, IOnTurnStart
    {
        public int Value { get; set; }
        public Armored(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nArmored {Value} - Gain {Value} Armor at the start of each turn.";
            return value;
        }

        #region INTERFACES

        public void OnTurnStart()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            int armor = 0;

            //if (Modifier)
            if (ModifierHolder is Item)
            { 
                armor = Game.Player.GainArmor(Value);
                return;
            }

            Unit? target = ModifierHolder as Enemy;
            if (target != null)
            {
                armor = target.GainArmor(Value);
            }
        }

        #endregion
    }
}


