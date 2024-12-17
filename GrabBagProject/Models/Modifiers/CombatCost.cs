using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers
{
    /// <summary>
    /// Specifies cost of using this item. Only allows use in combat.
    /// </summary>
    internal class CombatCost : Modifier, IUsable, IPayResources, IAfterUse, IOnTurnEnd
    {
        List<(string, int)> Costs { get; set; }
        int Cooldown { get; set; }
        protected int _currentCooldown = 0;
        public int CurrentCooldown { get { return _currentCooldown; } }
        public CombatCost(int cooldown = 0, params (string, int)[] costs)
        {
            Cooldown = cooldown;
            Costs = costs.ToList();
        }

        public override string ToString()
        {
            string value = base.ToString();
            if (Costs.Count > 0)
            {
                value += "\nCost to Use:";
                Costs.ForEach(p => value += $"\n{p.Item1} - {p.Item2}");
            }
            if (Cooldown > 0)
                value += $"\nCooldown - {Cooldown}";
            if (CurrentCooldown > 0)
                value += $"\nOn Cooldown - {CurrentCooldown}";
            return value;
        }

        public void GoOnCooldown()
        {
            _currentCooldown = Cooldown;
        }

        public int LowerCooldown(int amount)
        {
            amount = Math.Min(amount, _currentCooldown);
            _currentCooldown -= amount;
            return amount;
        }

        #region INTERFACES

        public bool IsUsable()
        {
            if (CurrentCooldown > 0) return false;

            bool usable = true;
            UsablePieces? usablePieces = (Game.ActiveController as CombatController)?.PulledPieces;
            if (usablePieces == null) return false;
            Costs.ForEach(c => usable = usable && usablePieces.ContainsPieces(c.Item1, c.Item2));
            return usable;
        }

        public void PayResources()
        {
            CombatController? combatController = Game.ActiveController as CombatController;
            if (combatController == null) return;
            combatController.SpendPieces(Costs.ToArray());
        }

        public void AfterUse()
        {
            GoOnCooldown();
        }

        public void OnTurnEnd()
        {
            if (_currentCooldown > 0)
                _currentCooldown--;
        }

        #endregion
    }
}