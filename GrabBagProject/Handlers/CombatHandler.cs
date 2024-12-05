using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Modifiers.Area;
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
    internal class CombatHandler : ActionHandler
    {
        CombatController _combatController;

        public CombatHandler(CombatController controller) : base()
        {
            _combatController = controller;
        }

        public override bool UseItem(Item item)
        {
            List<Modifier> modifiers = item.Modifiers;

            Enemy[] enemies = _combatController.AllEnemies;

            // If we require a target, prevent us from proceeding without one.
            if (enemies.Length > 1)
            {
                bool targetable = false;

                foreach (var mod in modifiers)
                {
                    targetable = targetable || mod is ITargetable;

                    // Cleave ignores Targetable ruling
                    if (mod is Cleave)
                    {
                        targetable = false;
                        break;
                    }
                }
                if (targetable)
                    return false;
            }

            return UseItem(item, _combatController.AllEnemies);
        }

        public virtual bool UseItem(Item item, params Unit?[] targets)
        {
            CombatItem? combatItem = item as CombatItem;
            if (combatItem == null)
                return base.UseItem(item);

            // Defining of Combat action.
            Snapshot snapshot = Game.ActiveController.Snapshot;
            snapshot.User = Game.Player;
            snapshot.Targets = targets;
            snapshot.UsedItem = item;
            snapshot.TemporaryStats = new StatContainer();

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

        public virtual void EnemyActions(params Enemy[] enemies)
        {
            foreach (Enemy enemy in enemies) EnemyAction(enemy);
        }

        protected virtual void EnemyAction(Enemy enemy)
        {
            // Defining of Combat action.
            Snapshot snapshot = Game.ActiveController.Snapshot;
            snapshot.User = enemy;
            snapshot.Targets = [Game.Player];
            snapshot.UsedItem = null;
            snapshot.TemporaryStats = new StatContainer();

            List<Modifier> modifiers = enemy.Modifiers;

            // IS USABLE
            bool usable = IsUsable(modifiers);
            if (!usable) return;

            // ON USE
            modifiers.ForEach(m => (m as IOnUse)?.OnUse());

            // AFTER USE
            modifiers.ForEach(m => (m as IAfterUse)?.AfterUse());
        }

        public virtual void UnitDamaged(Unit unit, int value)
        {
            // When Player is damaged, run OnDamaged check for every item in their Inventory.
            Player? player = unit as Player;
            if (player != null)
            {
                List<Item> allItems = player.Inventory.GetAllItems();
                allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnDamaged)?.OnDamaged(value)));
                return;
            }

            // When Enemy is damaged, run OnDamaged check on their modifiers.
            Enemy? enemy = unit as Enemy;
            if (enemy != null)
            {
                List<Modifier> modifiers = enemy.Modifiers;
                modifiers.ForEach(m => (m as IOnDamaged)?.OnDamaged(value));
                return;
            }
        }

        public virtual void TurnEnded()
        {
            Player player = Game.Player;

            // ON TURN END - PLAYER THEN ENEMIES
            List<Item> allItems = player.Inventory.GetAllItems();
            allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnTurnEnd)?.OnTurnEnd()));

            Enemy[] enemies = _combatController.AllEnemies;
            foreach(Enemy enemy in enemies)
            {
                enemy.Modifiers.ForEach(m => (m as IOnTurnEnd)?.OnTurnEnd());
            }

        }
    }
}
