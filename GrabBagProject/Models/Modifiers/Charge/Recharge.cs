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
    internal class Recharge : Modifier, IOnTurnEnd
    {
        public int Value;
        public Recharge(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nRecharge {Value} - Gain {Value} Charge at the end of each turn.";
        }

        #region INTERFACES
        public void OnTurnEnd()
        {
            Utils.FindModifier<Charge>(ModifierHolder.Modifiers)?.AddCharge(Value);
        }
        #endregion
    }
}
