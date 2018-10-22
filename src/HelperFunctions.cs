using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public static class HelperFunctions
    {
        public static void LoadResources()
        {
            SwinGame.LoadBitmapNamed("ChessBoard", "ChessBoard.png");
            string[] colors = { "Black", "White" };
            string[] kind = { "Pawn", "King", "Queen", "Knight", "Bishop", "Rook" };
            foreach (string c in colors)
            {
                foreach (string k in kind)
                {
                   // Console.WriteLine("loading:");
                    SwinGame.LoadBitmapNamed(c + k, c + k + ".png");
                   // Console.WriteLine(c + k + ": " + SwinGame.HasBitmap(c + k));
                }
            }
            SwinGame.LoadFontNamed("text","cour.ttf", 12);
        }
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

        public static Position GetNewPosition(Position position, List<int> deltaPosition)
        {
            return GetNewPosition(position, deltaPosition[0], deltaPosition[1]);
        }
        public static Position GetNewPosition(Position position, int deltaX, int deltaY)
        {
            List<int> tempPosition = GetAbsPos(position);
            tempPosition[0] += deltaX;
            tempPosition[1] += deltaY;
            return GetAbsPos(tempPosition);
        }

        public static Position PositionClicked ()
        {
            Point2D mouse = default (Point2D);
            mouse = SwinGame.MousePosition ();
            int row = 0;
            int column = 0;
            row = 7 - Convert.ToInt32 (Math.Floor (mouse.Y / 56.25));
            column = Convert.ToInt32 (Math.Floor ((mouse.X - 350) / 56.25));
            return (Position)((8 * row) + column);

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

        public static Position GetAbsPos(List<int> position)
        {
            return (Position)(8 * position[1] + position[0]);
        }

        public static PlayerColour GetOpponent(PlayerColour player)
        {
            return (player == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;
        }

        public static Piece NewPiece(Kind kind, Position pos, PlayerColour player)
        {
            switch (kind)
            {
                case Kind.Pawn  : return new Pawn(pos, player);
                case Kind.Rook  : return new Rook(pos, player);
                case Kind.Knight: return new Knight(pos, player);
                case Kind.Bishop: return new Bishop(pos, player);
                case Kind.Queen : return new Queen(pos, player);
            }
            return new NullPiece();
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
