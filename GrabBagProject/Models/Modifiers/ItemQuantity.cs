﻿using GrabBagProject.Actions;
using GrabBagProject.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Modifiers
{
    internal class ItemQuantity : Modifier, IUsable, IOnUse
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

        #region INTERFACES
        public void OnUse()
        {
            _quantity--;
        }

        public bool IsUsable()
        {
            return _quantity > 0;
        }
        #endregion

    }
}
