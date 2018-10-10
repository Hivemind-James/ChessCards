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

        public Player(PlayerColour player)
        {
            _hand = new List<Card>();
            Card card = new KillerQueen(1, player);
            for (int i = 0; i < 10; i++) _hand.Add(card);
        }

        public void DrawHand()
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                _hand[i].DrawSmall(i);
                //SwinGame.DrawRectangle(Color.Black, i * 80, 100, 80, 100);
            }
        }
    }
}
