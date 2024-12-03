using GrabBagProject.Handlers;
using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;

namespace GrabBagProject.Controllers
{
    /// <summary>
    /// Base Controller class
    /// </summary>
    internal class Controller : StatContainer
    {
        public bool Completed = false;

        public delegate void Call(params string[] args);

        public List<Command> Commands = new();
        public Dictionary<string, Call> Calls = new();
        protected ActionHandler _handler = new();

        public Snapshot Snapshot = new Snapshot();
        public Controller()
        {
            Constructor();
        }

        public virtual void Constructor()
        {
            Command command = new Command(
                "Use Item",
                "Use an item in your inventory.",
                ["use", "u"]
                );
            AddCommand(command, TryUseItem);
            command = new Command(
                "Inventory",
                "List current inventory items.",
                ["inventory", "inv", "i"]
                );
            AddCommand(command, Inventory);
            command = new Command(
                "View Bag",
                "List all available Pieces in your bag.",
                ["view", "v"]
                );
            AddCommand(command, ViewBag);
            command = new Command(
                "Quit Game",
                "As the name suggests, exit the game immediately.",
                ["quit", "q"]
                );
            AddCommand(command, QuitCommand);
        }

        public void AddCommand(Command command, Call call)
        {
            Commands.Add(command);
            foreach (string key in command.Keys)
                Calls.TryAdd(key, call);
        }

        public virtual void ParseInput(params string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(ToString());
                return;
            }
            string command = args[0];
            if (Calls.ContainsKey(command))
                Calls[command].Invoke(args);
            Console.WriteLine("");
        }

        public override string ToString()
        {
            string commands = "";
            foreach(Command command in Commands)
            {
                commands += command.ToString() + "\n";
            }
            return commands;
        }

        private void Inventory(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(Game.Player.Inventory.ToString());
                CombatController? combatController = this as CombatController;
                if (combatController != null)
                    Console.WriteLine($"\n{combatController.PulledPieces.ToString()}");
            }
            else
            {
                if (int.TryParse(args[1], out int value))
                {
                    Item? item = Game.Player.Inventory.GetItem(value);
                    if (item != null)
                        Console.WriteLine(item.ToString());
                }
            }
        }

        protected void ViewBag(string[] args)
        {
            Console.WriteLine(Game.Player.Bag.ToString());
        }

        protected void TryUseItem(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("To use an item in your inventory, type the number after use. Ex: 'use 1'.");
            }
            else
            {
                if (int.TryParse(args[1], out int value))
                {
                    Item? item = Game.Player.Inventory.GetItem(value);
                    if (item != null)
                    {
                        if (!UseItem(item))
                            Console.WriteLine($"Cannot use {item.Name} at this time.");
                    }
                }
            }
        }

        #region ITEM USAGE
        protected virtual bool UseItem(Item item)
        {
            return _handler.UseItem(item);
        }
        #endregion

        protected void QuitCommand(string[] args)
        {
            Program.GameLooping = false;
        }
    }
}
