using GrabBagProject.Handlers;
using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Modifiers.Attack;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;

namespace GrabBagProject.Controllers
{
    internal class CombatController : Controller
    {
        public Enemy Enemy { get; set; }
        public UsablePieces PulledPieces { get; set; }
        public override void Constructor()
        {
            _handler = new CombatHandler();
            Enemy = new Enemy("Test Enemy", 100,
                    new Attack(6));
            PulledPieces = new UsablePieces();
            Command command = new Command(
                "Pass",
                "When you've finished using your pieces, this ends your turn.",
                ["pass", "p"]
                );
            AddCommand(command, Pass);
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

        private void Pass(string[] args)
        {
            PullTurnPieces();
        }

        private void PullTurnPieces()
        {
            List<string> pulls = Game.Player.Bag.PullPieces();
            string message = "Pieces Pulled from Bag:\n";
            pulls.ForEach(p => message += p + " ");
            PulledPieces.AddPieces(pulls);
            Console.WriteLine(message);
        }
    }
}
