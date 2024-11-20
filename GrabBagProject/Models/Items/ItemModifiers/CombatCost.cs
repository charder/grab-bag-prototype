using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    /// <summary>
    /// Specifies cost of using this item. Only allows use in combat.
    /// </summary>
    internal class CombatCost : ItemModifier
    {
        List<Piece> Costs { get; set; }
        int Cooldown { get; set; }
        protected int _currentCooldown = 0;
        public int CurrentCooldown { get { return _currentCooldown; } }
        public CombatCost(int cooldown = 0, params Piece[] costs)
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
                Costs.ForEach(p => value += $"\n{p.Name} - {p.Value}");
            }
            if (Cooldown > 0)
                value += $"\nCooldown - {Cooldown}";
            if (CurrentCooldown > 0)
                value += $"\nOn Cooldown - {CurrentCooldown}";
            return value;
        }
    }
}
