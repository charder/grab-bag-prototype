using GrabBagProject.Actions;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
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
            // Prepare Snapshot of this Action.
            Snapshot snapshot = Game.ActiveController.Snapshot;
            snapshot.User = Game.Player;
            snapshot.Target = null;
            snapshot.UsedItem = item;
            snapshot.TemporaryStats = new StatContainer();

            CombatItem? combatItem = item as CombatItem;
            if (combatItem != null)
                return false;

            List<Modifier> modifiers = item.Modifiers;

            // IS USABLE
            bool usable = IsUsable(modifiers);
            if (!usable) return false;

            // PAY COSTS
            modifiers.ForEach(m => (m as IPayResources)?.PayResources());

            // ON USE
            modifiers.ForEach(m => (m as IOnUse)?.OnUse());

            // AFTER USE
            modifiers.ForEach(m => (m as IAfterUse)?.AfterUse());

            return true;
        }

        // Check if we can use the Item
        protected virtual bool IsUsable(List<Modifier> modifiers)
        {
            bool usable = true;

            foreach (Modifier modifier in modifiers)
            {
                IUsable? mod = modifier as IUsable;
                if (mod != null)
                    usable = usable && mod.IsUsable();
            }
            return usable;
        }
    }
}
