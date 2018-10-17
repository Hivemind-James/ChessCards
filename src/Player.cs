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
        private int _selected;

        public Player(PlayerColour player)
        {
            _hand = new List<Card>();
            Card card = new KillerQueen(1, player);
            for (int i = 0; i < 10; i++) _hand.Add(card);
            _selected = 0;
        }

        public void DrawHand()
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                _hand[i].DrawSmall(i);
                if (_selected > 0) _hand[_selected - 1].DrawLarge(0, 0);
                //SwinGame.DrawRectangle(Color.Black, i * 80, 100, 80, 100);
            }
        }

        public bool PlayCard()
        {
            bool cardResolved = false;
            switch (DoClick())
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
                    _selected = 1 + DoClick();
                    break;
                case 10 :
                    cardResolved = true;
                    break;
            }
            return cardResolved;
        }

        private int DoClick()
        {
            if (SwinGame.MousePosition().Y > 480)
            {
                Console.WriteLine((int)(SwinGame.MousePosition().X / 80));
                return (int)(SwinGame.MousePosition().X / 80);
            }
            else return 10;
        }
    }
}
