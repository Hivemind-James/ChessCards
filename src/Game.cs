using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class Game
    {
        private Dictionary<PlayerColour, Player> _players;
        private Board _board;
        private int _turn;
        private GameState _state;
        private Piece _selected;
        private Card _activeCard;

        public Game()
        {
            HelperFunctions.LoadResources();
            SwinGame.OpenGraphicsWindow("Secret Technique Chess", 800, 600);

            _players = new Dictionary<PlayerColour, Player>();
            foreach (PlayerColour player in Enum.GetValues(typeof(PlayerColour)))
            {
                _players.Add(player, new Player(player));
            }

            _board = new Board();
            _board.Setup();

            _turn = 1;

            _state = GameState.PlayCard;
            _activeCard = null;

        }

        public void DoMove()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                Position _newclick = HelperFunctions.PositionClicked();
                string output = _newclick.ToString();
                SwinGame.DrawText(output, Color.Black, 0, 20);
                Piece _newpiece = _board.Find(_newclick);


                if (_newpiece != null && _newpiece.Owner == ActivePlayer)
                {
                    _selected = _newpiece;
                    Console.WriteLine(_selected.Kind);
                }
                else if (_selected != null && _selected.CanMoveTo(_board, _newclick))
                {
                    _board.Remove(_newclick);
                    _board.Add(_newclick, _selected);
                    _board.Remove(_selected.Position);
                    _selected.NewPosition(_newclick);
                    _selected = null;
                    _turn++;
                    _state = GameState.PlayCard;
                }
            }
        }

        public void Play()
        {
            do
            {
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.White);
                switch (_state)
                {
                    case GameState.Setup:
                        Setup();
                        break;
                    case GameState.PlayCard:
                        PlayCard();
                        break;
                    case GameState.DoMove:
                        DoMove();
                        break;
                }
                if (_selected != null) SwinGame.DrawText(_selected.Kind.ToString(), Color.Black, 0, 20);
                SwinGame.DrawText(ActivePlayer.ToString(), Color.Black, 0, 0);
                Draw();
                SwinGame.RefreshScreen();
            } while (SwinGame.WindowCloseRequested() == false);

        }

        public void PlayCard()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_players[ActivePlayer].PlayCard(this)) _state = GameState.DoMove;
            }
        }

        public void Setup()
        {
            foreach (KeyValuePair<PlayerColour, Player> p in _players)
            {
                while (p.Value.HandSize < 10) // Don't know why It's doing this: Operator < cannot be applied to method groups and int.
                {
                    Random r = new Random();
                    p.Value.AddCard(r);

                }

            }

        }

        public void Draw()
        {
            //draw background
            //draw board
            //draw moves/card options
            //draw pieces
            _board.Draw(_selected);
            //draw cards
            _players[ActivePlayer].DrawHand();
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

        public bool Check()
        {
            List<Piece> opponentPieces = new List<Piece>();
            PlayerColour nonActivePlayer = HelperFunctions.GetOpponent(ActivePlayer);
            Piece _monarch = _board.Find(Kind.King, ActivePlayer);
            bool check = false;

            opponentPieces = _board.FindAllPlayerPeices(nonActivePlayer);
            foreach (Piece p in opponentPieces)
            {
                if (p.CanMoveTo(_board, _monarch.Position))
                {
                    check = true;
                }
            }
            return check;
        }

        public bool CheckMate()
        {
            List<Piece> pieces = new List<Piece>();
            pieces = _board.FindAllPlayerPeices(ActivePlayer);
            bool checkmate = false;
            int checkcount = 0;

            foreach (Piece p in pieces)
            {
                foreach (Position pos in _board.Cells.Keys)
                {
                    if (p.CanMoveTo(_board, pos))
                    {
                        Piece temp = _board.Find(pos);
                        _board.Remove(pos);
                        _board.Add(pos, p);
                        _board.Remove(p.Position);
                        if (Check() == false)
                        {
                            checkcount++;
                        }
                        _board.Add(p.Position, p);
                        _board.Remove(pos);
                        _board.Add(pos, temp);
                    }
                }
            }
            if (checkcount < 1)
            {
                checkmate = true;
            }
            return checkmate;
        }
    }
}
