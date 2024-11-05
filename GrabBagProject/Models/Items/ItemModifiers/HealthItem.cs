using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class HealthItem : ItemModifier
    {
        protected int _value;
        public HealthItem(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nOn Use: Heal {_value}";
        }
    }
}
