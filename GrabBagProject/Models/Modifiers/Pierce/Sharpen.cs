using GrabBagProject.Actions;
using GrabBagProject.Models.Modifiers.Base;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Pierce
{
    /// <summary>
    /// Increases Pierce after use this turn
    /// </summary>
    internal class Sharpen : StackingModifier, IAfterUse, IOnTurnEnd
    {
        public Sharpen(int value) : base(value) { }

        public override string ToString()
        {
            string value = base.ToString();
            value += $"\nSharpen {Value} - Gains {Value} Pierce after use this turn. (Current: {_activeStack})";
            return value;
        }

        #region INTERFACES

        public void AfterUse()
        {
            _activeStack += Value;
        }

        public void OnTurnEnd()
        {
            //TODO: REMOVE STACKS FROM PIERCE
            _activeStack = 0;
        }

        #endregion
    }
}