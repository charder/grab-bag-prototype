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
    /// Decay deals damage to the Modifier holder at the end of each turn.
    /// </summary>
    internal class Decay : Modifier, IOnTurnEnd
    {
        public int Value { get; set; }
        public Decay(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nDecay {Value} - Lose {Value} health at the end of each turn.";
            return value;
        }

        #region INTERFACES

        public void OnTurnEnd()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            Unit? user = ModifierHolder as Unit;
            if (user == null) return;

            Console.WriteLine($"{user.Name} loses {Value} health from Decay.");

            int damage = user.TakePierce(Value);

            (Game.ActiveController as CombatController)?.UnitDamaged(user, damage);
            return;
        }

        #endregion
    }
}


