using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class HelperFunctions
    {
        public static List<int> GetRelativePosition(Position origin, Position end)
        {
            //This gets the new position in terms of Y in order to check if the position is outside the board
            int oldPosition = origin.GetHashCode();
            int oldX = oldPosition % 8;
            int oldY = oldP

        }

        public static Piece Setup(int position)
        {
            // This function returns the correct piece for a given space during setup
            Piece piece = null;
            PlayerColour player = (position < 16) ? PlayerColour.White : PlayerColour.Black;
            switch (position)
            {
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    piece = new Pawn((Position)position, player);
                    break;
                case 0:
                case 7:
                case 56:
                case 63:
                    piece = new Rook((Position)position, player);
                    break;
                case 1:
                case 6:
                case 57:
                case 62:
                    piece = new Knight((Position)position, player);
                    break;
                case 2:
                case 5:
                case 58:
                case 61:
                    piece = new Bishop((Position)position, player);
                    break;
                case 3:
                case 59:
                    piece = new Queen((Position)position, player);
                    break;
                case 4:
                case 60:
                    piece = new King((Position)position, player);
                    break;
            }
            return piece;
        }
    }
}
