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
        public CombatCost()
        {

        }

        public override string ToString()
        {
            string value = base.ToString();
            return value;
        }
    }
}
