using GrabBagProject.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Controllers
{
    /// <summary>
    /// Base Controller class
    /// </summary>
    internal class Controller
    {
        public Dictionary<string, Command> Commands = new Dictionary<string, Command>();
        public Controller()
        {
            Command command = new Command("quit");
            Commands.Add(command.Name, command);
        }

        public virtual void ParseInput(params string[] args)
        {
            if (args.Length == 0)
                return;
            if (Commands.ContainsKey(args[0]))
                Program.GameLooping = false;
        }
    }
}
