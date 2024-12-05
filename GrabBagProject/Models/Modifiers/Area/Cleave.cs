using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Area
{
    /// <summary>
    /// Adding the Cleave Modifier to Items makes it hit all Enemies
    /// </summary>
    internal class Cleave : Modifier
    {
        public int Value { get; set; }
        public Cleave() { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nCleave - Hits all Enemies.";
            return value;
        }
    }
}


