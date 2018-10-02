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

        public abstract bool CanMoveTo(Board board, Position position);
        public abstract Bitmap MoveMap(Board board);

        public Piece(Position position, PlayerColour player)
        {
            NewPosition(position);
            _owner = player;
        }

        public virtual void NewPosition(Position position)
        {
            _position = position;
        }


        public override string ToString()
        {
            return Position.ToString() + ": " + Owner.ToString() + " " + Kind.ToString() + "\n";
        }

        public Position Position
        {
            get
            {
                return _position;
            }
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
    }
}
