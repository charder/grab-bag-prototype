using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Bag
{
    internal class Bag
    {
        public List<Piece> Pieces { get; set; }

        public Bag()
        {
            Pieces = new List<Piece>();
        }

        /// <summary>
        /// Add Piece to list of Pieces.
        /// </summary>
        /// <returns>If piece already exists in Bag object.</returns>
        public bool AddPiece(Piece piece)
        {
            foreach(Piece bagPiece in Pieces)
            {
                if (piece.Equals(bagPiece))
                {
                    piece.Quantity += bagPiece.Quantity;
                    return true;
                }
            }
            Pieces.Add(piece);
            return false;
        }

        /// <summary>
        /// Remove up to Quantity of Piece from Bag.
        /// </summary>
        /// <param name="removeAll">Ignore Piece Quantity and remove all of the specified Piece.</param>
        /// <returns>If piece existed in Bag object.</returns>
        public bool RemovePiece(Piece piece, bool removeAll = false)
        {
            Piece? foundPiece = null;
            foreach (Piece bagPiece in Pieces)
            {
                if (piece.Equals(bagPiece))
                {
                    foundPiece = bagPiece;
                    break;
                }
            }
            if (foundPiece != null)
            {
                int quantity = foundPiece.Quantity -= removeAll ? foundPiece.Quantity : piece.Quantity;
                if (quantity <= 0)
                    Pieces.Remove(foundPiece);
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
            count = Math.Min(count, Pieces.Count);
            List<Piece> rollOptions = new List<Piece>();
            foreach(Piece bagPiece in Pieces)
            {
                for (int i = 0; i < bagPiece.Quantity; i++)
                    rollOptions.Add(bagPiece);
            }
            for (int i = 0; i < count; i++)
            {
                Random random = new Random();
                int roll = random.Next(rollOptions.Count);
                pieces.Add(rollOptions[i]);
                rollOptions.RemoveAt(roll);
            }
            return pieces;
        }
    }
}
