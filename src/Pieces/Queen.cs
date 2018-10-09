using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Queen : Piece
    {
        public Queen(Position position, PlayerColour player) : base(position, player)
        {
            _kind = Kind.Queen;
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            bool canMove = false;
            bool hasSeenEnemy = false;
            List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
            Position current = position;

            if (Math.Abs(relativePos[0]) == Math.Abs(relativePos[1]) ||
                relativePos[0] == 0 || relativePos[1] == 0)
            {
                while (!(relativePos[0] == 0 && relativePos[1] == 0))
                {
                    if (board.Find(current).Owner != Owner)
                    {
                        canMove = true;
                        if (board.Find(current).Owner == HelperFunctions.GetOpponent(Owner))
                        {
                            if (hasSeenEnemy)
                            {
                                canMove = false;
                                break;
                            }
                            else hasSeenEnemy = true;
                        }
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


        public override Bitmap MoveMap(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
