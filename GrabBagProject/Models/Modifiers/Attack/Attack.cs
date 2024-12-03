using GrabBagProject.Actions;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
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

            int? damage = snapshot?.Target?.TakeDamage(Value);
            if (!damage.HasValue) return;

            //TODO: IN PROGRESS

        }

        #endregion
    }
}


