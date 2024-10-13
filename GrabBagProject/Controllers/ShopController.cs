using GrabBagProject.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Controllers
{
    internal class ShopController : Controller
    {
        public override void Constructor()
        {
            Command command = new Command(
                "Shop",
                "List current inventory shop inventory.",
                ["shop", "s"]
                );
            AddCommand(command, PrintShop);
            base.Constructor();
        }

        public override void ParseInput(params string[] args)
        {
            base.ParseInput(args);
        }

        private void PrintShop(string[] args)
        {

        }
    }
}
