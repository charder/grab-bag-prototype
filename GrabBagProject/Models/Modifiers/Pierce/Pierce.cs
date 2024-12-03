using GrabBagProject.Actions;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Pierce
{
    /// <summary>
    /// Pierce deals damage, ignoring armor.
    /// </summary>
    internal class Pierce : Modifier, IOnUse, ITargetable
    {
        public int Value { get; set; }
        public Pierce(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nPierce {Value} - Deal {Value} damage to target, ignoring armor.";
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


