using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    /// <summary>
    /// Serializable Piece for populating Bag objects from JSON.
    /// </summary>
    internal class PieceInstance
    {
        public Piece Piece { get; set; }
        public int Quantity { get; set; }
    }
}
