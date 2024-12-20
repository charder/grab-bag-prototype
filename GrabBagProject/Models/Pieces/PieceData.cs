﻿using System;
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

        public virtual string ToString(int quantity = 1)
        {
            return $"{Name} - {quantity}x - {Description} - {Type.ToString()}";
        }
    }

    internal enum PieceType
    {
        None = 0,
        Resource = 1,
        Buff = 2,
        Debuff = 3
    }
}
