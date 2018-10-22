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
        private Kind _monarch;

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

            _state = GameState.Setup;
            _activeCard = null;

            _monarch = Kind.King;

        }

        public void DoMove()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                Position _newClick = HelperFunctions.PositionClicked();
                string output = _newClick.ToString();
                SwinGame.DrawText(output, Color.Black, 0, 20);
                Piece _newpiece = _board.Find(_newClick);


                if (_newpiece != null && _newpiece.Owner == ActivePlayer)
                {
                    _selected = _newpiece;
                    Console.WriteLine(_selected.Kind);
                }
                else if (_selected != null && _selected.CanMoveTo(_board, _newClick))
                {
                    Piece target = _board.Find(_newClick);
                    _board.Remove(_newClick);
                    _board.Add(_newClick, _selected);
                    _board.Remove(_selected.Position);
                    if (!Check(ActivePlayer))
                    {
                        _selected.NewPosition(_newClick);
                        _selected = null;
                        _turn++;
                        _state = GameState.PlayCard;
                    }
                    else
                    {
                        _board.Remove(_newClick);
                        _board.Add(_selected.Position, _selected);
                        _board.Add(_newClick, target);
                    }
                    if (CheckMate(HelperFunctions.GetOpponent(ActivePlayer)))
                    {
                        //ActivePlayer Wins
                        DisplayWinner(ActivePlayer);
                    }
                }
            }
        }

        public void Play()
        {
            do
            {
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.White);
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    if (SwinGame.PointInRect(SwinGame.MousePosition(), 50, 460, 150, 50))
                    {
                        DisplayWinner(HelperFunctions.GetOpponent(ActivePlayer));
                        break;
                    }
                }
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
            _state = GameState.PlayCard;
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
            SwinGame.FillRectangle(Color.Gray, 50, 460, 150, 50);
            SwinGame.DrawRectangle(Color.Black, 50, 460, 150, 50);
            SwinGame.DrawText("Concede", Color.Black, 50, 460);
            string stateString = (_state == GameState.DoMove) ? ": Move a piece" : ": Play a card";
            stateString = ActivePlayer.ToString() + stateString;
            SwinGame.DrawText(stateString, Color.Black, 0, 0);
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

        public Kind Monarch
        {
            get { return _monarch; }
            set { _monarch = value; }
        }

        public bool Check(PlayerColour target)
        {
            List<Piece> opponentPieces = new List<Piece>();
            PlayerColour nonActivePlayer = HelperFunctions.GetOpponent(target);
            Position monarch = _board.BoardPosition(_monarch, target);
            bool check = false;

            opponentPieces = _board.FindAllPlayerPieces(nonActivePlayer);
            foreach (Piece p in opponentPieces)
            {
                if (p.CanMoveTo(_board, monarch))
                {
                    check = true;
                }
            }
            return check;
        }

        public bool CheckMate(PlayerColour target)
        {
            List<Piece> pieces = new List<Piece>();
            pieces = _board.FindAllPlayerPieces(target);
            bool checkmate = false;
            int checkcount = 0;
            //Dictionary<Position, Piece> copy;

            foreach (Piece p in pieces)
            {
                foreach (Position pos in Enum.GetValues(typeof(Position)))
                {
                    if (p.CanMoveTo(_board, pos))
                    {
                        Piece temp = _board.Find(pos);
                        _board.Remove(pos);
                        _board.Add(pos, p);
                        _board.Remove(p.Position);
                        if (Check(target) == false)
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

        private void DisplayWinner() { DisplayWinner(ActivePlayer); }
        private void DisplayWinner(PlayerColour player)
        {
            if (player == PlayerColour.White)
            {
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawText("WHITE WINS", Color.Black, "cour.ttf", 92, 100, 250);
            }
            else
            {
                SwinGame.ClearScreen(Color.Black);
                SwinGame.DrawText("BLACK WINS", Color.White, "cour.ttf", 92, 100, 250);
            }
            SwinGame.RefreshScreen();
            SwinGame.Delay(10000);
        }
    }
}
