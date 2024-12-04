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
    /// Thorns deals damage back to attacker when Attacked (specific actions like Attack and Pierce)
    /// </summary>
    internal class Thorns : Modifier, IBeingAttacked, IAfterUse
    {
        Unit? attacker = null;
        public int ReturnDamage { get; set; }
        public Thorns(int value)
        {
            ReturnDamage = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nThorns {ReturnDamage} - Deal {ReturnDamage} damage back when attacked.";
            return value;
        }

        #region INTERFACES

        public void BeingAttacked()
        {
            attacker = Game.ActiveController.Snapshot?.User;
        }

        public void AfterUse()
        {
            int? damage = attacker?.TakeDamage(ReturnDamage);

            if (!damage.HasValue || damage == 0) return;

            (Game.ActiveController as CombatController)?.UnitDamaged(attacker, damage.Value);

            attacker = null;
        }

        #endregion
    }
}


