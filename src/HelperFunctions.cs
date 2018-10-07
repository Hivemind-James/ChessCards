using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class HelperFunctions
    {
        //This function returns a list of integers (the first element being x and the second y).
        //The function is used in the Piece Child classes to help determine is a move is legal
        public static List<int> GetRelativePosition(Position origin, Position end)
        {
            List<int> positionDelta = new List<int>();
            int originPosition = origin.GetHashCode();
            int originX = originPosition % 8;
            int originY = originPosition / 8;
            int endPosition = end.GetHashCode();
            int endX = endPosition % 8;
            int endY = endPosition / 8;
            positionDelta.Add(endX - originX);
            positionDelta.Add(endY - originY);
            return positionDelta;
        }

        public static Position PositionClicked ()
        {
            Point2D mouse = default (Point2D);
            mouse = SwinGame.MousePosition ();
            int row = 0;
            int column = 0;
            row = Convert.ToInt32 (Math.Floor ((mouse.Y - 0) / (56.25 + 0)));
            column = Convert.ToInt32 (Math.Floor ((mouse.X + (SwinGame.ScreenWidth () - 450) / (56.25 + 0))));
            return (Position)(column * 8 + row);

        }

        public static List<int> GetAbsPos(Position position)
        {
            int x = position.GetHashCode() % 8;
            int y = position.GetHashCode() / 8;
            List<int> absPos = new List<int>();
            absPos.Add(x);
            absPos.Add(y);
            return absPos;
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
