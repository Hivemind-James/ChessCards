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
        private float _cellWidth;

        public Board()
        {
            _cells = new Dictionary<Position, Piece>();
            _x = 350;
            _y = 0;
            _cellWidth = 56.25f;
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

        public List<Piece> FindList(Kind kind, PlayerColour player)
        {
            List<Piece> pieces = new List<Piece>();
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player && piece.Value.Kind == kind) pieces.Add(piece.Value);
            }
            if (pieces.Count > 0) return pieces;
            else return null;
        }


        public List<Piece> FindAllPlayerPeices(PlayerColour player)
        {
            List<Piece> pieces = new List<Piece>();
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player) pieces.Add(piece.Value);
            }
            if (pieces.Count > 0) return pieces;
            else return null;
        }

        public Point2D GetPositionLocation(Position position)
        {
            Point2D location = new Point2D();
            List<float> coords = new List<float>();
            foreach (int i in HelperFunctions.GetAbsPos(position)) coords.Add(i);
            coords[1] = 7 - coords[1];
            coords[0] *= _cellWidth;
            coords[0] += _x;
            coords[1] *= _cellWidth;
            coords[1] += _y;
            location.X = coords[0];
            location.Y = coords[1];
            return location;
            
        }

        public bool Contains(Kind kind, PlayerColour player)
        {
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player && piece.Value.Kind == kind) return true;
            }
            return false;
        }

        public void Draw(Piece selected)
        {
            //Console.WriteLine(SwinGame.HasBitmap("ChessBoard"));
            SwinGame.DrawBitmap("ChessBoard", _x, _y);
            if (selected != null) selected.MoveMap(this);
            foreach (KeyValuePair<Position, Piece> position in _cells) position.Value.Draw(this);
        }

        public bool IsClear(Position begin, Position end)
        {
            List<int> relativePos = HelperFunctions.GetRelativePosition(begin, end);
            Position current = begin;
            if (Math.Abs(relativePos[0]) == Math.Abs(relativePos[1]) ||
                        relativePos[0] == 0 || relativePos[1] == 0)
            {
                while (!(relativePos[0] == 0 && relativePos[1] == 0))
                {
                    relativePos[0] -= Math.Sign(relativePos[0]);
                    relativePos[1] -= Math.Sign(relativePos[1]);
                    current = HelperFunctions.GetNewPosition(current, relativePos);
                    if (Find(current).Owner != PlayerColour.NoOwner) return false;
                }
                return true;
            }
            return false;
        }

        public int Count(Kind kind)
        {
            return Count(kind, PlayerColour.White) + Count(kind, PlayerColour.Black);
        }
        public int Count(Kind kind, PlayerColour player)
        {
            int count=0;
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Kind == kind && piece.Value.Owner == player) count++;
            }
            return count;
        }
        public int Count(PlayerColour player)
        {
            int count = 0;
            foreach (KeyValuePair<Position, Piece> piece in _cells)
            {
                if (piece.Value.Owner == player) count++;
            }
            return count;
        }

        public Dictionary<Position, Piece> Cells { get => _cells; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public float CellWidth { get => _cellWidth; set => _cellWidth = value; }
    }
}
