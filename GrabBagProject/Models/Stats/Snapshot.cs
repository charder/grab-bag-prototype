using GrabBagProject.Models.Items;
using GrabBagProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Stats
{
    internal class Snapshot
    {
        public Snapshot() { }

        public Unit? User;
        public Unit? Target;
        public Item? UsedItem;
        public StatContainer TemporaryStats = new StatContainer();
    }
}
