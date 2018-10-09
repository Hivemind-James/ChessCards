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
        }

        public void Add(Position position, Piece piece)
        {
            _cells.Add(position, piece);
        }

        public void Remove(Position position)
        {
            _cells.Remove (position);
        }

        public string CurrentBoardState()
        {
            string _state = "";
            foreach (KeyValuePair<Position, Piece> p in _cells)
            {
                _state += p.Key.ToString() + ": " + p.Value.Owner.ToString() + " " + p.Value.Kind.ToString() + "\n";
            }
            return _state;
        }

        public Piece Find(Position position)
        {
            if (_cells.ContainsKey(position))
            {
                return _cells[position];
            }
            return new NullPiece();
        }

        public bool Contains(Kind kind, PlayerColour player)
        {
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player && piece.Value.Kind == kind) return true;
            }
            return false;
        }
    }
}
