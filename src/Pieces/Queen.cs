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
            throw new NotImplementedException();
        }


        public override Bitmap MoveMap(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
