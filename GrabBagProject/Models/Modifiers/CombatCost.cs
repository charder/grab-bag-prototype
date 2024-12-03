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
    internal class CombatCost : Modifier, IUsable, IPayResources
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

        #region INTERFACES

        public bool IsUsable()
        {
            bool usable = true;
            UsablePieces? usablePieces = (Game.ActiveController as CombatController)?.PulledPieces;
            if (usablePieces == null) return false;
            Costs.ForEach(c => usable = usable && usablePieces.ContainsPieces(c.Item1, c.Item2));
            return usable;
        }

        public void PayResources()
        {
            UsablePieces? usablePieces = (Game.ActiveController as CombatController)?.PulledPieces;
            if (usablePieces == null) return;
            usablePieces.RemovePieces(Costs.ToArray());
        }

        #endregion
    }
}