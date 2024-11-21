using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Values.Integer
{
    /// <summary>
    /// Interface used to mark any property that needs an int value.
    /// </summary>
    internal class FlatInteger : IIntProperty
    {
        private int _value;

        public FlatInteger(int value)
        {
            _value = value;
        }

        public int GetValue()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
