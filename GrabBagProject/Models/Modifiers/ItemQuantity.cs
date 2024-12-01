using GrabBagProject.Models.Values.Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers
{
    internal class ItemQuantity : Modifier
    {
        protected int _quantity;
        public ItemQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public override string ToString()
        {
            string value = base.ToString();
            return value += $"\nQuantity: {_quantity.ToString()}";
        }
    }
}
