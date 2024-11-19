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
        public List<Piece> Pieces { get; set; }
        public Dictionary<string, int> PieceTotals { get; set; }
        public int Count
        {
            get { return Pieces.Count; }
        }

        public UsablePieces()
        {
            Pieces = new List<Piece>();
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
        public void AddPieces(List<Piece> pieces)
        {
            Pieces.AddRange(pieces);
            foreach(Piece piece in pieces)
            {
                string name = piece.Name;
                if (PieceTotals.ContainsKey(name))
                    PieceTotals[name] += piece.Value;
                else
                    PieceTotals.Add(name, piece.Value);
            }
        }


        /// <summary>
        /// Remove all Pieces from Piece List.
        /// </summary>
        /// <returns>List of removed Pieces.</returns>
        public List<Piece> RemovePieces()
        {

            Piece[] copyArray = new Piece[Pieces.Count];
            Pieces.CopyTo(copyArray);
            Pieces.Clear();
            PieceTotals.Clear();
            return copyArray.ToList();
        }

    }
}
