using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Pieces
{
    internal class Bag
    {
        public static Dictionary<string, PieceData> AllPieces { get; set; }
        public Dictionary<Piece, int> PieceDictionary { get; set; }

        public Bag(string piecesJsonFile)
        {
            PieceDictionary = new Dictionary<Piece, int>();

            AllPieces = new Dictionary<string, PieceData>();
            List<PieceData>? pieces = JsonBuilder.FromFile<List<PieceData>>(piecesJsonFile);
            pieces?.ForEach(p => AllPieces.Add(p.Name, p));
        }

        public override string ToString()
        {
            string contents = "Contents of Bag:\n";
            foreach(KeyValuePair<Piece, int> pair in PieceDictionary)
            {
                Piece pieceInstance = pair.Key;
                PieceData? pieceData;
                if (AllPieces.TryGetValue(pieceInstance.Name, out pieceData))
                    contents += pieceData.ToString(pieceInstance.Value, pair.Value) + "\n";
            }
            return contents;
        }

        /// <summary>
        /// Add Piece to list of Pieces.
        /// </summary>
        /// <returns>If piece already exists in Bag object.</returns>
        public bool AddPiece(Piece piece, int quantity = 1)
        {
            if (PieceDictionary.ContainsKey(piece))
            {
                PieceDictionary[piece] += quantity;
                return true;
            }
            PieceDictionary.Add(piece, quantity);
            return false;
        }

        /// <summary>
        /// Remove up to Quantity of Piece from Bag.
        /// </summary>
        /// <param name="removeAll">Ignore Piece Quantity and remove all of the specified Piece.</param>
        /// <returns>If piece existed in Bag object.</returns>
        public bool RemovePiece(Piece piece, bool removeAll = false)
        {
            if (PieceDictionary.ContainsKey(piece))
            {
                PieceDictionary[piece]--;
                if (PieceDictionary[piece] <= 0 || removeAll)
                    PieceDictionary.Remove(piece);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Randomly roll Pieces from Bag.
        /// </summary>
        /// <param name="count">Max number of returned Pieces</param>
        /// <returns>List of rolled Pieces</returns>
        public List<Piece> RollPieces(int count)
        {
            List<Piece> pieces = new List<Piece>();

            //TODO: FIX

            return pieces;
        }
    }
}
