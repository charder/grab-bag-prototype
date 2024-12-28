using GrabBagProject.Actions;
using GrabBagProject.Controllers;
using GrabBagProject.Models.Items;
using GrabBagProject.Models.Modifiers.Pieces;
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

namespace GrabBagProject.Models.Modifiers.Pieces
{
    /// <summary>
    /// Pull Pieces from Bag on use.
    /// </summary>
    internal class Pull : Modifier, IOnUse
    {
        public int Value { get; set; }
        public Pull(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nPull {Value} - Pull up to {Value} random Pieces from Bag.";
            return value;
        }

        #region INTERFACES

        public virtual void OnUse()
        {
            Bag bag = Game.Player.Bag;
            if (Value > 0)
            {
                CombatController? combatController = Game.ActiveController as CombatController;
                if (combatController is not null)
                {
                    List<string> pieces = bag.PullPieces(Value);
                    combatController.PulledPieces.AddPieces(pieces);
                    foreach(string piece in pieces)
                        Console.WriteLine($"\nPulled {piece} from Bag.");
                }
            }
        }

        #endregion
    }
}


