using GrabBagProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabBagProject.Models.Chips
{
    internal class Board
    {
        public Dictionary<string, (int, int)> Contents { get; set; }

        public Board(params (string, int)[] boardPieces)
        {
            Contents = new();
            foreach (var pair in boardPieces)
            {
                Contents.Add(pair.Item1, (0, pair.Item2));
            }
        }

        public override string ToString()
        {
            string contents = "Contents of Board:\n";
            foreach (KeyValuePair<string, (int, int)> pair in Contents)
            {
                string key = pair.Key;
                if (key.Equals("Credits"))
                    contents += $"\n{key} - {pair.Value.Item1}";
                else
                    contents += $"\n{key} - {pair.Value.Item1}/{pair.Value.Item2}";
            }
            return contents;
        }

        protected (int, int) PieceCount(string name)
        {
            (int, int) count = (0, 0);
            Contents.TryGetValue(name, out count);
            return count;
        }
    }
}
