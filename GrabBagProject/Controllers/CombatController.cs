using GrabBagProject.Handlers;
using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers;
using GrabBagProject.Models.Modifiers.Attack;
using GrabBagProject.Models.Modifiers.Block;
using GrabBagProject.Models.Modifiers.Pierce;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;

namespace GrabBagProject.Controllers
{
    internal class CombatController : Controller
    {
        protected Enemy _mainEnemy { get; set; }
        public List<Enemy> ActiveEnemies { get; set; }
        public UsablePieces PulledPieces { get; set; }
        public override void Constructor()
        {
            _handler = new CombatHandler(this);

            _mainEnemy = new Enemy("Pack Goblin", 30,
                             new Attack(5));

            ActiveEnemies = [
                _mainEnemy,
                new Enemy("Goblin", 10,
                    new Attack(3)),
                new Enemy("Goblin", 10,
                    new Attack(3)),
                new Enemy("Spear Goblin", 12,
                    new Pierce(2)),
            ];
            PulledPieces = new UsablePieces();
            Command command = new (
                "Pass",
                "When you've finished using your pieces, this ends your turn.",
                ["pass", "p"]
                );
            AddCommand(command, Pass);
            command = new (
                "Enemies",
                "Lists all Enemies currently in combat.",
                ["enemies", "e"]
                );
            AddCommand(command, Enemies);
            base.Constructor();
            StartCombat();
        }

        public override void ParseInput(params string[] args)
        {
            base.ParseInput(args);
        }

        public void StartCombat()
        {
            Game.Player.Bag.FillCurrentBag();
        }

        public void SpendPieces(params (string, int)[] pieces)
        {
            PulledPieces.RemovePieces(pieces);
            Bag bag = Game.Player.Bag;
            foreach((string, int) piece in pieces)
                bag.AddPieceToCurrentBag(piece.Item1, piece.Item2);
            //TODO: ADD STATS SPEND TO StatContainer WITHIN Snapshot
        }

        private void Pass(string[] args)
        {
            EnemyActions();

            TurnEnded();

            PullTurnPieces();
        }

        private void Enemies(string[] args)
        {
            for (int i = 0; i < ActiveEnemies.Count; i++)
            {
                Enemy enemy = ActiveEnemies[i];
                Console.WriteLine($"{i}. " + enemy.ToString());
            }
        }

        // CombatController handles targeting.
        protected override void TryUseItem(string[] args)
        {
            if (args.Length < 3)
            {
                base.TryUseItem(args);
                return;
            }
            int enemyTarget;
            if (int.TryParse(args[2], out enemyTarget))
            {
                if (ActiveEnemies.Count > enemyTarget)
                {
                    Enemy target = ActiveEnemies[enemyTarget];
                    if (int.TryParse(args[1], out int value))
                    {
                        Item? item = Game.Player.Inventory.GetItem(value);
                        if (item != null)
                        {
                            CombatHandler? combatHandler = _handler as CombatHandler;
                            if (combatHandler == null || !combatHandler.UseItem(item, target))
                                Console.WriteLine($"Cannot use {item.Name} at this time.");
                        }
                    }
                }
                else
                    Console.WriteLine($"{enemyTarget} is not a valid Enemy target.");
            }
            else
                Console.WriteLine($"{args[2]} is not a valid Enemy target.");
        }

        private void PullTurnPieces()
        {
            List<string> pulls = Game.Player.Bag.PullPieces();
            string message = "\nPieces Pulled from Bag:\n";
            pulls.ForEach(p => message += p + " ");
            PulledPieces.AddPieces(pulls);
            Console.WriteLine(message);
        }

        #region COMBAT HANDLER PASS THROUGH

        public virtual void UnitDamaged(Unit unit, int value)
        {
            (_handler as CombatHandler)?.UnitDamaged(unit, value);
        }

        public virtual void EnemyActions()
        {
            (_handler as CombatHandler)?.EnemyActions(ActiveEnemies.ToArray());
        }

        public virtual void EnemyDeath(Enemy enemy)
        {
            Console.WriteLine($"{enemy.Name} has been killed!");
            // END COMBAT
            if (enemy == _mainEnemy)
            {
                Game.ActiveController = new GameEndController();
                Console.WriteLine("Main enemy defeated. You win!");
            }
            ActiveEnemies.Remove(enemy);
        }

        public virtual void TurnEnded()
        {
            (_handler as CombatHandler)?.TurnEnded();
        }

        #endregion
    }
}
