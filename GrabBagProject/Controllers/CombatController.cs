using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Items.ItemHolders;

namespace GrabBagProject.Controllers
{
    internal class CombatController : Controller
    {
        public override void Constructor()
        {
            /*
            Command command = new Command(
                "Shop",
                "List current shop inventory.",
                ["shop", "s"]
                );
            AddCommand(command, Shop);
            command = new Command(
                "Buy",
                "Purchase an item from the shop.",
                ["buy","b"]
                );
            AddCommand(command, Buy);
            command = new Command(
                "Sell",
                "Sell an item in your inventory.",
                ["sell"]
                );
            AddCommand(command, Sell);
            command = new Command(
                "Leave Shop",
                "Finish shopping and leave the shop.",
                ["leave", "l"]
                );
            AddCommand(command, Leave);
            */
            base.Constructor();
        }

        public override void ParseInput(params string[] args)
        {
            base.ParseInput(args);
        }

        private void Leave(string[] args)
        {

        }
    }
}
