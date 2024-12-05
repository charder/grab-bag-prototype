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

namespace GrabBagProject.Models.Modifiers.Pierce
{
    /// <summary>
    /// Pierce deals damage, ignoring armor.
    /// </summary>
    internal class Pierce : Modifier, IOnUse, ITargetable
    {
        public int Value { get; set; }
        public Pierce(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nPierce {Value} - Deal {Value} damage to target, ignoring armor.";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            foreach (Unit? target in snapshot.Targets)
            {
                if (target == null) continue;

                Console.WriteLine($"\n{snapshot?.User?.Name} Pierce attacking {target.Name} for {Value}.");

                int damage = target.TakePierce(Value);
                if (damage == 0) continue;

                (Game.ActiveController as CombatController)?.UnitDamaged(target, damage);
            }
        }

        #endregion
    }
}


