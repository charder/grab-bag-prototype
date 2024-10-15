﻿using GrabBagProject.Models.Commands;
using GrabBagProject.Models.Items;
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
        public delegate void Call(params string[] args);

        public List<Command> Commands = new List<Command>();
        public Dictionary<string, Call> Calls = new Dictionary<string, Call>();
        public Controller()
        {
            Constructor();
        }

        public virtual void Constructor()
        {
            Command command = new Command(
                "Inventory",
                "List current inventory items.",
                ["inventory", "inv", "i"]
                );
            AddCommand(command, Inventory);
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
                PrintCommands();
                return;
            }
            string command = args[0];
            if (Calls.ContainsKey(command))
                Calls[command].Invoke(args);
            Console.WriteLine("");
        }

        private void Inventory(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(Game.Player.Inventory.ToString());
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

        private void PrintCommands()
        {
            foreach(Command command in Commands)
            {
                Console.WriteLine(command.ToString());
            }
            Console.WriteLine("");
        }

        private void QuitCommand(string[] args)
        {
            Program.GameLooping = false;
        }
    }
}
