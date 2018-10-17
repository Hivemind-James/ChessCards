using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Knight : Piece
    {
        public Knight(Position position, PlayerColour player) : base(position, player)
        {
            _kind = Kind.Knight;
            Name += "Knight";
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
            if (Math.Abs(relativePos[0]) == 1)
            {
                if (Math.Abs(relativePos[1]) == 2)
                {
                    if (board.Find(position).Owner != Owner) return true;
                }
            }
            else if (Math.Abs(relativePos[1]) == 1)
            {
                if (Math.Abs(relativePos[0]) == 2)
                {
                    if (board.Find(position).Owner != Owner) return true;
                }
            }
            return false;
        }
    }
}
