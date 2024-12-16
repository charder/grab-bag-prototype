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

namespace GrabBagProject.Models.Modifiers.Health
{
    /// <summary>
    /// Heal damage taken.
    /// </summary>
    internal class Regenerate : Modifier, IOnTurnEnd
    {
        public int Value { get; set; }
        public Regenerate(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nRegenerate {Value} - Gain {Value} health at the end of each turn.";
            return value;
        }

        #region INTERFACES

        public void OnTurnEnd()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            Unit? user = ModifierHolder as Unit;
            if (user == null) return;

            Console.WriteLine($"{user.Name} Heals for {Value}.");

            int heal = user.GainHealth(Value);
            return;
        }

        #endregion
    }
}


