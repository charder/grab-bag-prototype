using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Controllers
{
    /// <summary>
    /// Base Controller class
    /// </summary>
    internal class Controller
    {
        public Controller()
        {

        }

        public virtual void ParseInput(params string[] args)
        {
            if (args.Length == 0)
                return;
        }
    }
}
