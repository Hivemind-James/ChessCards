using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        private bool _lastMoveDouble;

        public Pawn(Position position, PlayerColour player) : base (position, player)
        {
            _kind = Kind.Pawn;
            Name += "Pawn";
        }
        public override bool CanMoveTo(Board board, Position position)
        {
            int maxDistance = (!_hasMoved) ? 2 : 1;
            List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
            switch (Owner)
            {
                case PlayerColour.White:
                    // returns if the position is empty and the correct distance from the pawn
                    if (relativePos[1] <= maxDistance &&
                        relativePos[1] > 0 &&
                        relativePos[0] == 0 &&
                        board.Find(position).Owner == PlayerColour.NoOwner) return true;
                    // returns if the diagonal has an enemy piece
                    if (relativePos[1] == 1 &&
                        Math.Abs(relativePos[0]) == 1 &&
                        board.Find(position).Owner == PlayerColour.Black) return true;
                    break;
                case PlayerColour.Black:
                    if (relativePos[1] >= -maxDistance &&
                        relativePos[1] < 0 &&
                        relativePos[0] == 0 &&
                        board.Find(position).Owner == PlayerColour.NoOwner) return true;
                    if (relativePos[1] == -1 &&
                        Math.Abs(relativePos[0]) == 1 &&
                        board.Find(position).Owner == PlayerColour.White) return true;
                    break;
            }
            return false;
        }

        public override void NewPosition(Position position)
        {
            _hasMoved = true;
            if (Math.Abs(HelperFunctions.GetRelativePosition(Position, position)[1]) == 2) _lastMoveDouble = true;
            else _lastMoveDouble = false;
            base.NewPosition(position);
        }
    }
}
