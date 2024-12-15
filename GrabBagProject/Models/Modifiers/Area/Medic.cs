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
    /// Adding the Medic Modifier to an Enemy causes their Heal to affect all Active Enemies.
    /// </summary>
    internal class Medic : Modifier
    {
        public int Value { get; set; }
        public Medic() { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nMedic - Heal affects all Enemies.";
            return value;
        }
    }
}


