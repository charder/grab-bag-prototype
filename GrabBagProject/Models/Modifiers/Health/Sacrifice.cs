using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Modifiers.Area;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Health
{
    /// <summary>
    /// User suffers damage on Use.
    /// </summary>
    internal class Sacrifice : Modifier, IOnUse
    {
        public int Value { get; set; }
        public Sacrifice(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nSacrifice {Value} - Lose {Value} health on use.";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            Unit? user = snapshot?.User;
            if (user is null) return;

            Console.WriteLine($"{user.Name} sacrifices {Value} Health.");
            int damage = user.TakePierce(Value);

            (Game.ActiveController as CombatController)?.UnitDamaged(user, damage);
            return;
        }

        #endregion
    }
}


