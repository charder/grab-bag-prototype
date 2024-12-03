using GrabBagProject.Actions;
using GrabBagProject.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers.Base
{
    /// <summary>
    /// Attack deals damage, which can be blocked by armor.
    /// </summary>
    internal abstract class StackingModifier(int value) : Modifier
    {
        public int Value { get; set; } = value;
        protected int _activeStack = 0;
    }
}