using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Commands
{
    internal class Command
    {
        public Command(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
