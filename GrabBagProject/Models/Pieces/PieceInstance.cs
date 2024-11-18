using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    internal class PieceInstance
    {
        public string Name { get; set; }
        public int Value { get; set; } 
        public int Quantity { get; set; }

        public Piece GetPiece()
        {
            return new Piece() { Name = Name, Value = Value };
        }
    }
}
