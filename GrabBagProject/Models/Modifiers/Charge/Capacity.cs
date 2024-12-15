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
    internal class Capacity : Modifier
    {
        public int Value;
        public Capacity(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nCapacity {Value} - Max Charge is {Value}.";
        }
    }
}
