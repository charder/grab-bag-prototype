using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Modifiers.Area;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
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

            // If we require a target, prevent us from proceeding without one.
            if (_combatController.ActiveEnemies.Count > 1)
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

            return UseItem(item, _combatController.ActiveEnemies.ToArray());
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

            // ATTACK CHECK
            if (modifiers.Any(m => (m as IAmAttack) != null))
            {
                foreach (Unit? target in targets)
                {
                    Enemy? enemy = target as Enemy;
                    if (enemy == null) continue;

                    enemy.Modifiers.ForEach(m => (m as IBeingAttacked)?.BeingAttacked());
                }
            }

            // AFTER USE
            modifiers.ForEach(m => (m as IAfterUse)?.AfterUse());

            return true;
        }

        public virtual void EnemyActions(params Enemy[] enemies)
        {
            foreach (Enemy enemy in enemies) enemy.ClearArmor();
            foreach (Enemy enemy in enemies) EnemyAction(enemy);
        }

        protected virtual void EnemyAction(Enemy enemy)
        {
            if (enemy.IsDead) return;

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

            // ATTACK CHECK
            if (modifiers.Any(m => (m as IAmAttack) != null))
            {
                Player? player = Game.Player;
                List<Item> allItems = player.Inventory.GetAllItems();
                allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IBeingAttacked)?.BeingAttacked()));
            }

            // AFTER USE
            modifiers.ForEach(m => (m as IAfterUse)?.AfterUse());
        }

        public virtual void UnitDamaged(Unit unit, int value)
        {
            // When Player is damaged, run OnDamaged for every item in their Inventory.
            Player? player = unit as Player;
            if (player != null)
            {
                List<Item> allItems = player.Inventory.GetAllItems();
                allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnDamaged)?.OnDamaged(value)));
                if (player.IsDead)
                {
                    Game.ActiveController = new GameEndController();
                    Console.WriteLine("You have died. Game Over!");
                }
                return;
            }

            // When Enemy is damaged, run OnDamaged on their modifiers, and check for death.
            Enemy? enemy = unit as Enemy;
            if (enemy != null)
            {
                List<Modifier> modifiers = enemy.Modifiers;
                modifiers.ForEach(m => (m as IOnDamaged)?.OnDamaged(value));
                if (enemy.IsDead)
                {
                    modifiers.ForEach(m => (m as IOnDeath)?.OnDeath());

                    // Check against item OnKill effects.
                    Snapshot snapshot = Game.ActiveController.Snapshot;
                    Item? usedItem = snapshot.UsedItem;
                    usedItem?.Modifiers?.ForEach(m => (m as IOnKill)?.OnKill());
                    _combatController.EnemyDeath(enemy);
                }
                
                return;
            }
        }

        public virtual void StartCombat()
        {
            Player player = Game.Player;

            // ON COMBAT START - PLAYER THEN ENEMIES
            List<Item> allItems = player.Inventory.GetAllItems();
            allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnCombatStart)?.OnCombatStart()));

            var enemies = _combatController.EnemyPool;
            foreach (Enemy enemy in enemies)
            {
                enemy.Modifiers.ForEach(m => (m as IOnCombatStart)?.OnCombatStart());
            }

            TurnStart();
        }

        public virtual void TurnStart()
        {
            Player player = Game.Player;
            player.ClearArmor();

            // ON TURN START - PLAYER THEN ENEMIES
            List<Item> allItems = player.Inventory.GetAllItems();
            allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnTurnStart)?.OnTurnStart()));

            var enemies = _combatController.ActiveEnemies;
            foreach (Enemy enemy in enemies)
            {
                enemy.Modifiers.ForEach(m => (m as IOnTurnStart)?.OnTurnStart());
            }
        }

        public virtual void TurnEnded()
        {
            Player player = Game.Player;

            // ON TURN END - PLAYER THEN ENEMIES
            List<Item> allItems = player.Inventory.GetAllItems();
            allItems.ForEach(i => i.Modifiers.ForEach(m => (m as IOnTurnEnd)?.OnTurnEnd()));

            var enemies = _combatController.ActiveEnemies;
            foreach(Enemy enemy in enemies)
            {
                enemy.Modifiers.ForEach(m => (m as IOnTurnEnd)?.OnTurnEnd());
            }
        }
    }
}
