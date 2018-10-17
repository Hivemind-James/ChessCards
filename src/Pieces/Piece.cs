using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    abstract public class Piece
    {
        protected Kind _kind;
        private PlayerColour _owner;
        private Position _position;
        private string _name;

        public abstract bool CanMoveTo(Board board, Position position);

        public Piece(Position position, PlayerColour player)
        {
            _position = position;
            _owner = player;
            _name = (player == PlayerColour.White) ? "White" : "Black";
        }

        public virtual void NewPosition(Position position)
        {
            _position = position;
        }


        public override string ToString()
        {
            return Position.ToString() + ": " + Owner.ToString() + " " + Kind.ToString() + "\n";
        }

        public virtual void Draw(Board board)
        {
            List<double> coords = new List<double>();
            foreach (int i in HelperFunctions.GetAbsPos(Position)) coords.Add(i);
            coords[1] = 7 - coords[1];
            coords[0] *= 56.25;
            coords[0] += board.X;
            coords[1] *= 56.25;
            coords[1] += board.Y;
            //Console.WriteLine(Name + ": " + SwinGame.HasBitmap(Name));
            SwinGame.DrawBitmap(Name, (float)coords[0] + 5, (float)coords[1] + 5);
        }

        public virtual void MoveMap(Board board)
        {
            foreach (Position p in Enum.GetValues(typeof(Position)))
            {
                if (CanMoveTo(board, p))
                {
                    Point2D point = board.GetPositionLocation(p);
                    SwinGame.FillRectangle(Color.Red, point.X, point.Y, 58, 58);
                }
            }
        }

        public Position Position
        {
            get
            {
                return _position;
            }
            set { _position = value; }
        }

        public Kind Kind
        {
            get { return _kind; }
        }

        public PlayerColour Owner
        {
            get
            {
                return _owner;
            }
        }

        public string Name { get => _name; set => _name = value; }
    }
}
