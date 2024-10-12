using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Units
{
    internal class Unit
    {
        public int CurrentHealth { get; set; }
        public int Health { get; set; }

        public void BuildUnit()
        {
            CurrentHealth = Health;
        }
    }
}
