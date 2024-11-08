using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class DamageModifier : ItemModifier
    {
        protected int _value;
        public DamageModifier(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nOn Use: Deal {GetDamageValue()} damage";
        }

        public virtual int GetDamageValue()
        {
            return _value;
        }
    }
}
