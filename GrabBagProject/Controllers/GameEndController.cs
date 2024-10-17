using GrabBagProject.Models.Commands;

namespace GrabBagProject.Controllers
{
    internal class GameEndController : Controller
    {
        public override void Constructor()
        {
            Command command = new Command(
                "Restart Game",
                "As the name suggests, exit the game immediately.",
                ["restart", "r"]
                );
            AddCommand(command, RestartCommand);
            command = new Command(
                "Quit Game",
                "As the name suggests, exit the game immediately.",
                ["quit", "q"]
                );
            AddCommand(command, QuitCommand);
        }

        private void RestartCommand(string[] args)
        {
            Program.RestartGame = true;
            QuitCommand(args);
        }
    }
}
