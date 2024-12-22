using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Models.Stats;
using GrabBagProject.Models.Units;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Cooldown
{
    /// <summary>
    /// Locked prevents cooldown lowering.
    /// </summary>
    internal class Locked : Modifier
    {
        internal Locked() { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nLocked - Item cannot have its active cooldown lowered.";
            return value;
        }
    }
}


