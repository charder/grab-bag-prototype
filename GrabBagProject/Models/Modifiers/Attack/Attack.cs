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

namespace GrabBagProject.Models.Modifiers.Attack
{
    /// <summary>
    /// Attack deals damage, which can be blocked by armor.
    /// </summary>
    internal class Attack : Modifier, IOnUse, ITargetable
    {
        public int Value { get; set; }
        public Attack(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nAttack {Value} - Deal {Value} damage to target";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            Snapshot snapshot = Game.ActiveController.Snapshot;

            foreach(Unit? target in snapshot.Targets)
            {
                if (target == null) continue;

                Console.WriteLine($"{snapshot?.User?.Name} Attacking {target.Name} for {Value}.");

                int damage = target.TakeDamage(Value);
                if (damage == 0) continue;

                (Game.ActiveController as CombatController)?.UnitDamaged(target, damage);
            }
        }

        #endregion
    }
}


