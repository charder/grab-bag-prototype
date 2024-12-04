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
            Snapshot snapshot = Game.ActiveController.Snapshot;

            Unit? user = snapshot?.User;
            if (user == null) return;

            Console.WriteLine($"{user.Name} Blocking for {Value}.");

            int block = user.GainArmor(Value);
            return;
        }

        #endregion
    }
}


