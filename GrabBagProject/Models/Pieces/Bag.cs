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
        public Dictionary<string, int> FullBag { get; set; }
        public Dictionary<string, int> CurrentBag { get; set; }
        public int PullsPerTurn { get; set; }
        protected int _count = 0;
        public int Count
        {
            get { return _count; }
        }

        public Bag(string piecesJsonFile, int pullsPerTurn)
        {
            // Populate info about Pieces from JSON.
            AllPieces = new Dictionary<string, PieceData>();
            List<PieceData>? pieces = JsonBuilder.FromFile<List<PieceData>>(piecesJsonFile);
            pieces?.ForEach(p => AllPieces.Add(p.Name, p));

            CurrentBag = new();
            FullBag = new();

            PullsPerTurn = pullsPerTurn;
        }

        public override string ToString()
        {
            string contents = "Contents of Bag:\n";
            foreach (KeyValuePair<string, int> pair in FullBag)
            {
                contents += PieceToString(pair.Key, pair.Value) + "\n";
            }
            return contents;
        }

        public static string PieceToString(string name, int quantity)
        {
            PieceData? pieceData;
            if (AllPieces.TryGetValue(name, out pieceData))
                return pieceData.ToString(quantity);
            return string.Empty;
        }



        #region ADD/REMOVE PIECES
        public void FillCurrentBag()
        {
            CurrentBag.Clear();
            foreach(KeyValuePair<string, int> pieces in FullBag)
            {
                AddPieceToCurrentBag(pieces.Key, pieces.Value);
            }
        }

        public List<string> PullPieces(bool bonusPulls = false, int pulls = 0)
        {
            return PullPieces(bonusPulls ? PullsPerTurn + pulls : PullsPerTurn);
        }

        public void AddPieceToCurrentBag(string name, int quantity = 1)
        {
            AddPiece(CurrentBag, name, quantity);
        }

        public void AddPieceToFullBag(string name, int quantity = 1)
        {
            AddPiece(FullBag, name, quantity);
        }

        protected void AddPiece(Dictionary<string, int> bag, string name, int quantity)
        {
            if (bag.ContainsKey(name))
            {
                bag[name] += quantity;
                return;
            }
            bag.Add(name, quantity);
        }


        public void RemovePieceFromCurrentBag(string name, int quantity = -1)
        {
            RemovePiece(CurrentBag, name, quantity);
        }

        public void RemovePieceFromFullBag(string name, int quantity = -1)
        {
            RemovePiece(FullBag, name, quantity);
        }

        protected void RemovePiece(Dictionary<string, int> bag, string name, int quantity)
        {
            if (bag.TryGetValue(name, out int value))
            {
                if (quantity == -1 || value <= quantity)
                {
                    bag.Remove(name);
                    return;
                }
                bag[name] -= quantity;
            }
        }

        /// <summary>
        /// Randomly pull Pieces from Bag.
        /// </summary>
        /// <param name="count">Max number of returned Pieces</param>
        /// <returns>List of pulled Pieces</returns>
        public List<string> PullPieces(int count)
        {
            List<string> bagPieces = new();
            List<string> rolledPieces = new();

            foreach (string piece in CurrentBag.Keys)
            {
                int quantity = CurrentBag[piece];
                for (int i = 0; i < quantity; i++)
                    bagPieces.Add(piece);
            }
            count = Math.Min(count, bagPieces.Count);

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int roll = random.Next(bagPieces.Count);
                string rolledPiece = bagPieces[roll];
                rolledPieces.Add(rolledPiece);

                // Reduce Bag's count of the Piece, and prevent it from being rolled again here.
                RemovePieceFromCurrentBag(rolledPiece, 1);
                bagPieces.RemoveAt(roll);
            }

            return rolledPieces;
        }
        #endregion
    }
}
