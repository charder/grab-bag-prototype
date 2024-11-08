using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class HealthModifier : ItemModifier
    {
        protected int _value;
        public HealthModifier(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nOn Use: Heal {GetHealthValue()}";
        }

        public virtual int GetHealthValue()
        {
            return _value;
        }
    }
}
