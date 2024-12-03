using GrabBagProject.Actions;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Block
{
    /// <summary>
    /// Block adds armor, which can block incoming damage.
    /// </summary>
    internal class Block : Modifier, IOnUse
    {
        public int Value { get; set; }
        public Block(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nBlock {Value} - Gain {Value} armor";
            return value;
        }

        #region INTERFACES

        public void OnUse()
        {
            return;
        }

        #endregion
    }
}


