using GrabBagProject.Actions;
using GrabBagProject.Models.Modifiers.Base;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Attack
{
    /// <summary>
    /// Increases Attack after use this turn
    /// </summary>
    internal class Flurry : StackingModifier, IAfterUse, IOnTurnEnd
    {
        public Flurry(int value) : base(value) { }

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
        }

        public void OnTurnEnd()
        {
            //TODO: REMOVE STACKS FROM ATTACK
            _activeStack = 0;
        }

        #endregion
    }
}