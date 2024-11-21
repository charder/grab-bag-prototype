using GrabBagProject.Models.Values.Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class DamageModifier : ItemModifier
    {
        protected IIntProperty _value;
        public DamageModifier(IIntProperty value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nOn Use: Deal {_value.ToString()} damage";
        }

        public virtual int GetDamageValue()
        {
            return _value.GetValue();
        }
    }
}
