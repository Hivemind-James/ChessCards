using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Board
    {
        private Dictionary<Position, Piece> _cells;

        public Board()
        {
            _cells = new Dictionary<Position, Piece>();
        }

        public void Setup()
        {
            for (int i = 0; i < 16; i++) _cells.Add((Position)i, HelperFunctions.Setup(i));
            for (int i = 48; i < 64; i++) _cells.Add((Position)i, HelperFunctions.Setup(i));
            foreach (KeyValuePair<Position, Piece> p in _cells)
            {
                Console.WriteLine(p.Key.ToString() + ": " + p.Value.Owner.ToString() + " " + p.Value.Kind.ToString());
            }
        }

    }
}
