using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class King : Piece
    {
        private bool _hasMoved;
        public King(Position position, PlayerColour player) : base(position, player)
        {
            _kind = Kind.King;
            _hasMoved = false;
            Name += "King";
        }

        public override bool CanMoveTo (Board board, Position position)
        {
            bool canMove = false;
            List<int> relativePos = HelperFunctions.GetRelativePosition (Position, position);
            if (Math.Abs (relativePos [0]) <= 1 && Math.Abs (relativePos [1]) <= 1) if (board.Find (position).Owner != Owner) canMove = true;
            return canMove; 
        }

        public override Bitmap MoveMap(Board board)
        {
            throw new NotImplementedException();
        }

        public override void NewPosition (Position position)
        {
            base.NewPosition (position);
            _hasMoved = true;
        }

        private bool HasMoved
        {
            get { return _hasMoved; }
        }
    }
}
