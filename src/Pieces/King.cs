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
        public King(Position position, PlayerColour player) : base(position, player)
        {
            _kind = Kind.King;
        }

        public override bool CanMoveTo(Board board, Position position)
        {
            throw new NotImplementedException();
        }

        public override Bitmap MoveMap(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
