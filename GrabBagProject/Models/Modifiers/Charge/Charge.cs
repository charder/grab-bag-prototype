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
    internal class Charge : Modifier, IUsable, IPayResources, IAfterUse
    {
        protected int _baseCharge;
        protected int _charge;
        public Charge(int charge)
        {
            _baseCharge = charge;
            _charge = charge;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nCharge {_charge} - Item can be used {_charge} times this combat.";
        }

        public void AddCharge(int charge)
        {
            if (Utils.FindModifier<Finite>(ModifierHolder.Modifiers) != null) return;
            Capacity? capacity = Utils.FindModifier<Capacity>(ModifierHolder.Modifiers);
            _charge = capacity == null ? _charge + charge : Math.Min(capacity.Value, _charge + charge);
        }

        #region INTERFACES
        public void PayResources()
        {
            _charge--;
        }

        public bool IsUsable()
        {
            return _charge > 0;
        }

        public void AfterUse()
        {
            //TODO: ADD Consumable CHECK.
        }
        #endregion

    }
}
