using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Offensive
{
    /// <summary>
    /// Pierce deals damage to armor.
    /// </summary>
    internal class Corrosion : Modifier, IAmAttack, IOnUse, ITargetable
    {
        public int Value { get; set; }
        public Corrosion(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nCorrosion {Value} - Deal {Value} damage to target's armor.";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            // Attack Modifier groups Pierce and Corrosion into one damage "instance".
            if (Utils.FindModifier<Attack>(ModifierHolder?.Modifiers) is not null) return;

            Snapshot snapshot = Game.ActiveController.Snapshot;

            foreach (Unit? target in snapshot.Targets)
            {
                if (target == null) continue;

                Console.WriteLine($"\n{snapshot?.User?.Name} Corroding {target.Name} for {Value}.");

                int damage = target.TakeCorrosion(Value);
            }
        }

        #endregion
    }
}


