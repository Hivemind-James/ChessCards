using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Bishop : Piece
    {
        public Bishop(Position position, PlayerColour player) : base(position, player)
        {
            _kind = Kind.Bishop;
            Name += "Bishop";
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            bool canMove = false;
            List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
            Position current = position;

            if (Math.Abs(relativePos[0]) == Math.Abs(relativePos[1]) && relativePos[0] != 0)
            {
                if (board.Find(current).Owner != Owner)
                {
                    relativePos[0] -= Math.Sign(relativePos[0]);
                    relativePos[1] -= Math.Sign(relativePos[1]);
                    current = HelperFunctions.GetNewPosition(Position, relativePos);
                    canMove = true;
                }
                while (relativePos[0] != 0)
                {
                    if (board.Find(current).Owner == PlayerColour.NoOwner)
                    {
                        canMove = true;
                        relativePos[0] -= Math.Sign(relativePos[0]);
                        relativePos[1] -= Math.Sign(relativePos[1]);
                        current = HelperFunctions.GetNewPosition(Position, relativePos);
                    }
                    else
                    {
                        canMove = false;
                        break;
                    }
                }
            }
            return canMove;
        }
    }
}
