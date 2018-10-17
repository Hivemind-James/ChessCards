using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class NullPiece : Piece
    {
        public NullPiece() : base(Position.NotAPosition, PlayerColour.NoOwner)
        {
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            return false;
        }
    }
}
