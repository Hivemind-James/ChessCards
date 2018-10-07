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
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            bool canMove = false;
            bool hasSeenEnemy = false;
            List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
            Position current = position;
            int xSign = Math.Sign(relativePos[0]);
            int ySign = Math.Sign(relativePos[1]);

            if (Math.Abs(relativePos[0]) == Math.Abs(relativePos[1]) && relativePos[0] != 0)
            {
                while (relativePos[0] != 0)
                {
                    if (board.Find(current) == null || board.Find(current).Owner != Owner)
                    {
                        canMove = true;
                        relativePos[0] -= xSign;
                        relativePos[1] -= ySign;
                        List<int> originPos = HelperFunctions.GetAbsPos(Position);
                        current = (Position)(8*(originPos[0]+relativePos[0])+originPos[1]+relativePos[1]);
                        if (board.Find(current) != null && board.Find(current).Owner != Owner)
                        {
                            if (hasSeenEnemy)
                            {
                                canMove = false;
                                break;
                            }
                            else canMove = true;
                        }
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
