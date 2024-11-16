using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    internal class Piece
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public PieceType Type { get; set; }

        public virtual Piece Build(string name, string description, int value, PieceType type, int quantity = 1)
        {
            Name = name;
            Description = description;
            Value = value;
            Type = type;
            Quantity = quantity;
            return this;
        }

        public override string ToString()
        {
            return $"{Name} {Value} - {Description} - {Type.ToString()}";
        }

        public bool Equals(Piece other)
        {
            return other.Name.Equals(Name) && other.Value == Value;
        }
    }

    internal enum PieceType
    {
        None = 0,
        Resource = 1,
        Money = 2,
        Buff = 3,
        Debuff = 4
    }
}
