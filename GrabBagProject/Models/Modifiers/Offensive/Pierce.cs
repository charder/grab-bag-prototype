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
    /// Pierce deals damage, ignoring armor.
    /// </summary>
    internal class Pierce : Modifier, IAmAttack, IOnUse, ITargetable
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
            // Attack Modifier groups Pierce and Corrosion into one damage "instance".
            if (Utils.FindModifier<Attack>(ModifierHolder?.Modifiers) is not null) return;

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


