using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;

namespace GrabBagProject.Controllers
{
    internal class CombatController : Controller
    {
        public override void Constructor()
        {
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

        }
    }
}
