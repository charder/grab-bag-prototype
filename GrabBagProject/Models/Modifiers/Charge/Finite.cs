using GrabBagProject.Actions;
using GrabBagProject.Models.Stats;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Charge
{
    internal class Finite : Modifier
    {
        public Finite() { }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nFinite - Cannot gain Charge in combat.";
        }
    }
}
