using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Game
    {
        private Dictionary<PlayerColour, Player> _players;
        private Board _board;
        private int _turn;
        private GameState _state;

        public Game()
        {
            _players = new Dictionary<PlayerColour, Player>();
            foreach (PlayerColour player in Enum.GetValues(typeof(PlayerColour)))
            {
                //_players.Add(player, new Player(player));
            }

            _board = new Board();
            //_board.Setup();

            _turn = 1;

            _state = GameState.Setup;
        }

        public void DoMove()
        {
            throw new NotImplementedException();
        }

        public void PlayCard()
        {
            throw new NotImplementedException();
        }

        public PlayerColour ActivePlayer
        {
            get
            {
                return (_turn % 2 == 1) ? PlayerColour.White : PlayerColour.Black;
            }
        }

        public int Turn
        {
            get
            {
                return _turn;
            }
        }

        public Board Board
        {
            get
            {
                return _board;
            }
        }
    }
}
