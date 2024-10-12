using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Items
{
    internal class Item : IInteractable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string GetDescription()
        {
            return Description;
        }
    }
}
