using GrabBagProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject
{
    internal class Game
    {
        string? input;
        Controller activeController = new Controller();

        public Game()
        {
            Console.WriteLine("Welcome to Grab Bag Brawl! For a list of input options, press enter without typing anything, or type 'options'");
        }
        public void Loop()
        {
            input = Console.ReadLine();
            string[] inputs = input == null ? [] : input.Split(' ');
            activeController.ParseInput(inputs);
        }
    }
}
