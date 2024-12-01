using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    internal class UsablePieces
    {
        public Dictionary<string, int> PieceTotals { get; set; }

        public UsablePieces()
        {
            PieceTotals = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            string contents = "Available Piece Values:\n";
            foreach(KeyValuePair<string, int> pair in PieceTotals)
            {
                contents += $"{pair.Key} - {pair.Value}\n";
            }
            return contents;
        }

        /// <summary>
        /// Add List of Pieces to existing List.
        /// </summary>
        public void AddPieces(List<string> pieces)
        {
            foreach(string piece in pieces)
                AddPiece(piece, 1);
        }

        public void AddPiece(string name, int count = 1)
        {
            if (PieceTotals.ContainsKey(name))
                PieceTotals[name] += count;
            else
                PieceTotals.Add(name, count);
        }

        /// <summary>
        /// Remove specified Piece counts from PieceTotals
        /// </summary>
        public void RemovePieces(params (string, int)[] pieces)
        {
            foreach (var pieceCount in pieces)
                RemovePiece(pieceCount.Item1, pieceCount.Item2);
        }

        public void RemovePiece(string name, int count = -1)
        {
            if (PieceTotals.ContainsKey(name))
            {
                if (count < 0 || PieceTotals[name] <= count)
                {
                    PieceTotals.Remove(name);
                    return;
                }
                PieceTotals[name] -= count;
            }
        }

        public bool ContainsPieces(string name, int count = 1)
        {
            return PieceTotals.ContainsKey(name) && PieceTotals[name] >= count;
        }

    }
}
