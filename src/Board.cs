using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Board
    {
        private Dictionary<Position, Piece> _cells;
        private int _x;
        private int _y;
        private double _cellWidth;

        public Board()
        {
            _cells = new Dictionary<Position, Piece>();
            _x = SwinGame.ScreenWidth() - 450;
            _y = 0;
            _cellWidth = 56.25;
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

        public Piece Find(Kind kind, PlayerColour player)
        {
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player && piece.Value.Kind == kind) return piece.Value;
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

        public void Draw()
        {
            //Console.WriteLine(SwinGame.HasBitmap("ChessBoard"));
            SwinGame.DrawBitmap("ChessBoard", _x, _y);
            foreach (KeyValuePair<Position, Piece> position in _cells) position.Value.Draw(this);
        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
    }
}
