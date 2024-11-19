using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Units;

namespace GrabBagProject.Controllers
{
    internal class CombatController : Controller
    {
        public UsablePieces PulledPieces { get; set; }
        public override void Constructor()
        {
            PulledPieces = new UsablePieces();
            Command command = new Command(
                "Pass",
                "When you've finished using your pieces, this ends your turn.",
                ["pass", "p"]
                );
            AddCommand(command, Pass);
            base.Constructor();
        }

        public override void ParseInput(params string[] args)
        {
            base.ParseInput(args);
        }

        private void Pass(string[] args)
        {
            ReturnPieces();
            PullTurnPieces();
        }

        private void PullTurnPieces()
        {
            List<Piece> pulls = Game.Player.Bag.PullPieces();
            string message = "Pieces Pulled from Bag:\n";
            pulls.ForEach(p => message += Bag.PieceToString(p, 1) + "\n");
            PulledPieces.AddPieces(pulls);
            Console.WriteLine(message);
        }

        private void ReturnPieces()
        {
            PulledPieces.RemovePieces().ForEach(p => Game.Player.Bag.AddPiece(p));
        }
    }
}
