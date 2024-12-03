using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Stats;
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
    internal class CombatHandler : ActionHandler
    {
        CombatController? _combatController;

        public CombatHandler() : base()
        {
            _combatController = Game.ActiveController as CombatController;
        }

        public override bool UseItem(Item item)
        {
            CombatItem? combatItem = item as CombatItem;
            if (combatItem == null)
                return base.UseItem(item);

            // Defining of Combat action.
            Snapshot snapshot = Game.ActiveController.Snapshot;
            snapshot.User = Game.Player;
            snapshot.Target = _combatController?.Enemy;
            snapshot.UsedItem = item;
            snapshot.TemporaryStats = new StatContainer();



            return true;
        }
    }
}
