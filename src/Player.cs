using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Player
    {
        private List<Card> _hand;
        private Card _selected;
        private PlayerColour _playerColour;

        public Player(PlayerColour player)
        {
            _hand = new List<Card>();
            //_hand.Add(new Castle(_playerColour));

            _selected = null;

            _playerColour = player;
        }

        public int HandSize
        {
            get { return _hand.Count; }
        } 

        public void AddCard(Random r)
        {

            _hand.Add(CardGenerator.GenerateCard(r, _playerColour));
        }

        public void DrawHand()
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                _hand[i].DrawSmall(i);
                if (_selected != null)
                {
                    _selected.DrawLarge(0, 0);
                }
                SwinGame.DrawRectangle(Color.Black, 50, 400, 150, 50);
                SwinGame.DrawText("Skip to Move", Color.Black, 50, 400);            }
        }

        public bool PlayCard(Game game)
        {
            bool cardResolved = false;
            int result = DoClick(game);
            switch (result)
            {
                case 0  :   //First Card
                case 1  :
                case 2  :
                case 3  :
                case 4  :
                case 5  :
                case 6  :
                case 7  :
                case 8  :
                case 9  :   //Last Card
                    _selected = _hand[result];
                    break;
                case 10 :
                    cardResolved = true;
                    _selected = null;
                    break;
                default :
                    break;
            }
            return cardResolved;
        }

        private int DoClick(Game game)
        {
            if (SwinGame.MousePosition().Y > 480)
            { 
                Console.WriteLine((int)(SwinGame.MousePosition().X / 80));
                return (int)(SwinGame.MousePosition().X / 80);
            }
            if (SwinGame.PointInRect(SwinGame.MousePosition(), 50, 400, 150,50)) return 10;
            if (_selected != null && _selected.Resolve(game)) return 10;
            return 11;
        }
    }
}
