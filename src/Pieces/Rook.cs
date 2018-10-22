using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Rook : Piece
    {
        private bool _hasMoved;

        public Rook(Position position, PlayerColour player) : base(position, player)
        {
            _hasMoved = false;
            _kind = Kind.Rook;
            Name += "Rook";
        }

        public override bool CanMoveTo (Board board, Position position)
        {
            bool canMove = false;
            List<int> relativePos = HelperFunctions.GetRelativePosition (Position, position);
            Position current = position;

            if (relativePos [0] == 0 || relativePos [1] == 0) {
                if (board.Find(current).Owner != Owner)
                {
                    relativePos[0] -= Math.Sign(relativePos[0]);
                    relativePos[1] -= Math.Sign(relativePos[1]);
                    current = HelperFunctions.GetNewPosition(Position, relativePos);
                    canMove = true;
                }
                while (!(relativePos [0] == 0 && relativePos [1] == 0)) {
                    if (board.Find (current).Owner == PlayerColour.NoOwner) {
                        canMove = true;
                        relativePos [0] -= Math.Sign (relativePos [0]);
                        relativePos [1] -= Math.Sign (relativePos [1]);
                        current = HelperFunctions.GetNewPosition (Position, relativePos);
                    } else {
                        canMove = false;
                        break;
                    }
                }
            }
            return canMove;
        }

        public override void NewPosition (Position position)
        {
            base.NewPosition (position);
            _hasMoved = true;
        }
        public bool HasMoved
        {
            get { return _hasMoved; }
        }
    }
}
