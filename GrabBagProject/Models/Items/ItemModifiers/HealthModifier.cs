using GrabBagProject.Models.Values.Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items.ItemModifiers
{
    internal class HealthModifier : ItemModifier
    {
        protected IIntProperty _value;
        public HealthModifier(IIntProperty value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nOn Use: Heal {_value.ToString()}";
        }

        public virtual int GetHealthValue()
        {
            return _value.GetValue();
        }
    }
}
