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
    internal interface IIntProperty
    {
        public abstract int GetValue();
        public abstract string ToString();
    }
}
