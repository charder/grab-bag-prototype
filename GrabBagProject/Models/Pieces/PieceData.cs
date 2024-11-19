using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    internal class PieceData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PieceType Type { get; set; }

        public virtual PieceData Build(string name, string description, PieceType type)
        {
            Name = name;
            Description = description;
            Type = type;
            return this;
        }

        public virtual string ToString(int value, int quantity = 1)
        {
            return $"{Name} {value} - {quantity}x - {Description} - {Type.ToString()}";
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

    internal struct Piece
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
