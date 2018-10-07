using System;
using SwinGameSDK;
namespace MyGame
{
    public class DoMove
    {
		Position new_position = new Position;
		Position old_position = new Position;
        List<int> relativePos = HelperFunctions.GetRelativePosition(Position, position);
		List<int> PositionClicked = new List<int>();

		Piece new_piece = new Peice();
        public DoMove ()
        {
			if (SwinGame.MouseClicked(MouseButton.LeftButton))
			{
				PositionClicked = return_position();  //get position

			    new_piece = _board.Find(PositionClicked);
				if (new_piece != null && new_piece.Owner == ActivePlayer)
				{ 
					_selected = new_piece;
				} 

				else if (_board.Find(_selected).CanMoveTo(new_position)){
                        _selected = new_piece;
				}
				else{


				}
			

			}


                
        }
		public List<int> return_position()
		{
			List<int> position = new List<int>();
			position.Add(SwinGame.MouseX());
			position.Add(SwinGame.MouseY());

			return position;
		}
			public void Move(Position X, Position Y)
			{

			}
    }
}
// How do we get the X and Y position? How can we give the position to the new piece? Enum is not a Matrix. It's a long row. We need a Matrix.