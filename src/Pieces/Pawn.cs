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
        }
        public override bool CanMoveTo(Board board, Position position)
        {
            return false;
        }

        public override Bitmap MoveMap(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
