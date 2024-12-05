using GrabBagProject.Actions;
using GrabBagProject.Models.Modifiers.Base;
using GrabBagProject.Models.Pieces;
using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Block
{
    /// <summary>
    /// Increases Block after use this turn.
    /// </summary>
    internal class Fortify : StackingModifier, IAfterUse, IOnTurnEnd
    {
        public Fortify(int value) : base(value) { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nFlurry {Value} - Gains {Value} Attack after use this turn. (Current: {_activeStack})";
            return value;
        }

        #region INTERFACES

        public void AfterUse()
        {
            _activeStack += Value;
            Block? block = Utils.FindModifier<Block>(ModifierHolder.Modifiers);
            if (block == null) return;
            block.Value += Value;
        }

        public void OnTurnEnd()
        {
            Block? block = Utils.FindModifier<Block>(ModifierHolder.Modifiers);
            if (block != null)
                block.Value -= _activeStack;
            _activeStack = 0;
        }

        #endregion
    }
}