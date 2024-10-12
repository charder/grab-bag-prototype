using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Units
{
    internal class Player : Unit
    {
        public Player(int health)
        {
            Health = health;
            BuildUnit();
        }
    }
}
