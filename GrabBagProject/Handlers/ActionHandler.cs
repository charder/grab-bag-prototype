using GrabBagProject.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Handlers
{
    /// <summary>
    /// Handles interactions on behalf of Controllers.
    /// </summary>
    internal class ActionHandler
    {
        public virtual bool UseItem(Item item)
        {
            CombatItem? combatItem = item as CombatItem;
            if (combatItem != null)
                return false;
            return true;
        }
    }
}
