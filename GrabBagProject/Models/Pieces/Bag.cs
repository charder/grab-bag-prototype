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
        public int PullsPerTurn { get; set; }
        protected int _count = 0;
        public int Count
        {
            get { return _count; }
        }

        public Bag(string piecesJsonFile, int pullsPerTurn)
        {
            PieceDictionary = new Dictionary<Piece, int>();

            AllPieces = new Dictionary<string, PieceData>();
            List<PieceData>? pieces = JsonBuilder.FromFile<List<PieceData>>(piecesJsonFile);
            pieces?.ForEach(p => AllPieces.Add(p.Name, p));
            PullsPerTurn = pullsPerTurn;
        }

        public override string ToString()
        {
            string contents = "Contents of Bag:\n";
            foreach(KeyValuePair<Piece, int> pair in PieceDictionary)
            {
                Piece pieceInstance = pair.Key;
                contents += PieceToString(pieceInstance, pair.Value) + "\n";
            }
            return contents;
        }

        public static string PieceToString(Piece piece, int quantity)
        {
            PieceData? pieceData;
            if (AllPieces.TryGetValue(piece.Name, out pieceData))
                return pieceData.ToString(piece.Value, quantity);
            return string.Empty;
        }

        /// <summary>
        /// Add Piece to list of Pieces.
        /// </summary>
        /// <returns>If piece already exists in Bag object.</returns>
        public bool AddPiece(Piece piece, int quantity = 1)
        {
            _count += quantity;
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
                _count -= removeAll ? PieceDictionary[piece] : 1;
                PieceDictionary[piece]--;
                if (PieceDictionary[piece] <= 0 || removeAll)
                    PieceDictionary.Remove(piece);
                return true;
            }
            return false;
        }

        public List<Piece> PullPieces(bool bonusPulls = false, int pulls = 0)
        {
            return PullPieces(bonusPulls ? PullsPerTurn + pulls : PullsPerTurn);
        }

        /// <summary>
        /// Randomly pull Pieces from Bag.
        /// </summary>
        /// <param name="count">Max number of returned Pieces</param>
        /// <returns>List of pulled Pieces</returns>
        public List<Piece> PullPieces(int count)
        {
            List<Piece> bagPieces = new List<Piece>();
            List<Piece> rolledPieces = new List<Piece>();

            foreach(Piece piece in PieceDictionary.Keys)
            {
                int quantity = PieceDictionary[piece];
                for (int i = 0; i < quantity; i++)
                    bagPieces.Add(piece);
            }
            count = Math.Min(count, bagPieces.Count);

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int roll = random.Next(bagPieces.Count);
                Piece rolledPiece = bagPieces[roll];
                rolledPieces.Add(rolledPiece);

                // Reduce Bag's count of the Piece, and prevent it from being rolled again here.
                RemovePiece(rolledPiece);
                bagPieces.RemoveAt(roll);
            }

            return rolledPieces;
        }
    }
}
