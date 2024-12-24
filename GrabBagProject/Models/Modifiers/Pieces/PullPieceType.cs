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
    /// Swift lowers the active cooldowns of Items.
    /// </summary>
    internal class PullPieceType : Modifier, IOnUse
    {
        protected string _name;
        protected string _pieceName;
        public int Value { get; set; }
        public PullPieceType(string pieceName, int value, string name) 
        {
            _pieceName = pieceName;
            Value = value;
            _name = name;
        }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\n{_name} {Value} - Pull up to {Value} {_pieceName} Pieces from Bag.";
            return value;
        }

        #region INTERFACES

        public virtual void OnUse()
        {
            Bag bag = Game.Player.Bag;
            int value = Math.Min(Value, bag.PieceCountInCurrentBag(_pieceName));
            if (value > 0)
            {
                CombatController? combatController = Game.ActiveController as CombatController;
                if (combatController is not null)
                {
                    bag.RemovePieceFromCurrentBag(_pieceName, value);
                    combatController.PulledPieces.AddPiece(_pieceName, value);
                    Console.WriteLine($"\nPulled {value} {_pieceName} from Bag.");
                }
            }
        }

        #endregion
    }
}

internal class Reload : PullPieceType { public Reload(int value) : base("Power", value, "Reload") { } }
internal class Reinforce : PullPieceType { public Reinforce(int value) : base("Guard", value, "Reinforce") { } }
internal class Restock : PullPieceType { public Restock(int value) : base("Utility", value, "Restock") { } }
internal class Reenergize : PullPieceType { public Reenergize(int value) : base("Energy", value, "Reenergize") { } }


