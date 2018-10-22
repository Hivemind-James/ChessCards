using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    abstract public class Card
    {
        protected int _minTurn;
        protected bool _used;
        private PlayerColour _owner;
        private string _name;
        private string _description;


        protected float _smallWidth;
        protected float _smallHeight;
        protected float _largeWidth;
        protected float _largeHeight;

        protected Rectangle _boundingbox;

        protected Color textColor;
       
        public Card(int turn, PlayerColour player, string name) : this (turn, player)
        {
            _name = name;
        }
        public Card(int turn, PlayerColour player)
        {
            _minTurn = turn;
            _owner = player;
            _used = false;

            _smallWidth = 80;
            _smallHeight = 120;
            _largeWidth = 250;
            _largeHeight = 350;

            _boundingbox = new Rectangle();
        }

        public Card(PlayerColour player) : this (0, player)
        {}

        public abstract bool IsPlayable(Game game);
        public abstract bool Resolve(Game game);
        public virtual void DrawSmall(int count)
        {
            _boundingbox.X = count * _smallWidth;
            _boundingbox.Y = SwinGame.ScreenHeight() - _smallHeight;
            _boundingbox.Width = _smallWidth;
            _boundingbox.Height = _smallHeight;
            SwinGame.DrawRectangle(Color.Black, _boundingbox);
            SwinGame.DrawText(_name, Color.Black, Color.White, "text", FontAlignment.AlignCenter, _boundingbox);
            _boundingbox.Y += 20;
            SwinGame.DrawText(MinimumTurn.ToString(), Color.Black, Color.White, "text", FontAlignment.AlignCenter, _boundingbox);
        }
        public virtual void DrawLarge(int x, int y)
        {
            SwinGame.DrawRectangle(Color.Black, x, y, _largeWidth, _largeHeight);
            SwinGame.DrawText(Description, Color.Black, x, y + 30);
            string turnTemp = "You can play this card";
            SwinGame.DrawText(turnTemp, Color.Black, x, y + 50);
            turnTemp = "on or after turn " + MinimumTurn.ToString();
            SwinGame.DrawText(turnTemp, Color.Black, x, y + 60);
        }
        //public virtual void DrawOptions() { };
        public int MinimumTurn
        {
            get
            {
                return _minTurn;
            }
        }

        public PlayerColour Owner
        {
            get
            {
                return _owner;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }

    public class KillPiece : Card
    {
        private Kind _target;
        private PlayerColour _enemy;
        private Position _selection;

        public KillPiece(PlayerColour owner, Random random) : base (owner)
        {
            _target = GetRandomKind(random);
            _enemy = (owner == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;
            _selection = Position.NotAPosition;
            _minTurn = _target.GetHashCode() * 5;
            Description = "Click an opponent's " + _target.ToString() + " to kill it";
            Name = "Kill a " + _target.ToString(); 
        }


        private Kind GetRandomKind(Random random)
        {
            return (Kind)(1 + random.Next(5));
        }

        public override bool IsPlayable(Game game)
        {
            return game.Board.Contains(_target, _enemy) && game.Turn >= MinimumTurn && !_used;
        }

        public override bool Resolve(Game game)
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                Piece p = game.Board.Find(HelperFunctions.PositionClicked());
                if (p.Kind == _target && p.Owner == HelperFunctions.GetOpponent(Owner) && IsPlayable(game))
                {
                    game.Board.Remove(p.Position);
                    _used = true;
                    return true;
                }
            }
            return false;
        }
    }

    public class Promote : Card
    {
        private Kind _target;


        public Promote (PlayerColour owner, Random random) : base(owner)
        {
            _target = GetRandomKind(random);
            _minTurn = _target.GetHashCode() * 5;
            Description = "Click a piece to upgrade it to a " + _target.ToString();
            Name = "Promote to " + _target.ToString();

        }

        private Kind GetRandomKind(Random random)
        {
            return (Kind)(1 + random.Next(5));
        }

        public override bool IsPlayable(Game game)
        {
            bool isPlayable = true;
            if (_target == Kind.Queen && game.Board.Contains(Kind.Queen, Owner)) isPlayable = false;
            isPlayable &= game.Turn >= MinimumTurn && !_used;
            return isPlayable;
        }

        public override bool Resolve(Game game)
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                Position pos = HelperFunctions.PositionClicked();
                Piece p = game.Board.Find(pos);
                if (p.Kind < _target && IsPlayable(game) && p.Kind > 0 && p.Owner == Owner)
                {
                    game.Board.Remove(pos);
                    game.Board.Add(pos, HelperFunctions.NewPiece(_target, pos, Owner));
                    _used = true;
                    return true;
                }
            }
            return false;
        }
    }

    public class Demote : Card
    {
        private List<Kind> _targets;
        private List<Kind> _promoOptions;
        private PlayerColour _enemy;


        public Demote(int turn, PlayerColour owner, List<Kind> targets, List<Kind> promotionOptions) : base(turn, owner)
        {
            _targets = targets;
            _promoOptions = promotionOptions;
        }
        
        public override bool IsPlayable(Game game)
        {
            bool isPlayable = false;
            foreach (Kind target in _targets)
            {
                isPlayable = game.Board.Contains(target, _enemy) && game.Turn >= MinimumTurn;
                if (isPlayable) break;
            }
            return isPlayable;
        }

        public override bool Resolve(Game game)
        {
            return false;
        }
    }

    public class KillerQueen : Card
    {
        public KillerQueen(PlayerColour player) : base(20, player, "Killer Queen")
        {
            Description = "Click your queen to kill each piece around it";
        }

        public override void DrawSmall(int count)
        {
            base.DrawSmall(count);
        }

        public override bool IsPlayable(Game game)
        {
            if (game.Turn < MinimumTurn) return false;
            Queen queen = game.Board.Find(Kind.Queen, Owner) as Queen;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (game.Board.Find(HelperFunctions.GetNewPosition(queen.Position, new List<int>() { i, j })).Kind == Kind.King) return false;
            return true;
        }

        public override bool Resolve(Game game)
        {
            Position _click = HelperFunctions.PositionClicked();
            Piece queen = game.Board.Find(_click);
            bool result = false;
            int i;
            int j;
            if (queen.Kind == Kind.Queen && queen.Owner == Owner && IsPlayable(game))
            {
                for (i = -1; i < 2; i++)
                {
                    for (j = -1; j < 2; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            Position kill = HelperFunctions.GetNewPosition(queen.Position, i, j);
                            game.Board.Remove(kill);
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
    }

    public class Fortify : Card
    {
        public Fortify(int turn, PlayerColour player) : base(turn, player) { }
        public override bool IsPlayable(Game game)
        {
            //You have at least 1 rook with an empty space next to it
            return false;
        }

        public override bool Resolve(Game game)
        {
            //you select an empty space next to a rook you control
            //a barricade piece is placed in the selected space
            return false;
        }
    }

    public class Kagemusha : Card
    {
        public Kagemusha(int turn, PlayerColour player) : base(turn, player) { }

        public override bool IsPlayable(Game game)
        {
            // you have a king without atleast 1 empty space next to it
            return false;
        }

        public override bool Resolve(Game game)
        {
            //player chooses 2 empty spaces next to their king (or the king's space)
            //The king goes to the first space
            //a body double is created in the second space
            return false;
        }
    }

    public class FourHorsemen : Card
    {
        public FourHorsemen(PlayerColour player) : base(30, player, "Four Horsemen")
        {
            Description = "Allows you to promote units to knights as long as you have less than 4, click each unit to upgrade";
        }

        public override bool IsPlayable(Game game)
        {
            return  game.Turn >= MinimumTurn &&
                    game.Board.Count(Kind.Knight, Owner) < 4 &&
                    game.Board.Count(Owner) > 4;
        }

        public override bool Resolve(Game game)
        {
            if (game.Board.Count(Kind.Knight, Owner) < 4)
            {
                Position _click = HelperFunctions.PositionClicked();
                Piece first = game.Board.Find(_click);
                if (first.Owner == Owner && first.Kind < Kind.Queen && first.Kind > 0 && IsPlayable(game))
                {
                    game.Board.Remove(_click);
                    game.Board.Add(_click, new Knight(_click, Owner));
                }
            }
            return false;
        }
    }

    public class Castle : Card
    {
        List<Rook> _rooks;

        public Castle(PlayerColour owner) : base(0, owner)
        {
        }

        public override bool IsPlayable(Game game)
        {
            _rooks = new List<Rook>();
            King king = game.Board.Find(Kind.King, Owner) as King;
            List<Piece> rooks = game.Board.FindList(Kind.Rook, Owner);
            if (rooks != null && !king.HasMoved)
            {
                foreach (Rook rook in rooks)
                {
                    if (!rook.HasMoved && game.Board.IsClear(king.Position, rook.Position))
                    {
                        _rooks.Add(rook);
                    }
                }
            }
            return _rooks.Count > 0 && game.Turn >= MinimumTurn;
        }

        public override bool Resolve(Game game)
        {
            //Click which rook to castle with
            //King is moved 2 spaces towards selected rook
            //rook is moved to the opposite side of the king
            return false;
        }
    }

    public class Sidestep : Card
    {
        Position _firstclick;
        Position _secondclick;
        public Sidestep(PlayerColour player) : base(5, player, "Sidestep")
        {
            Description = "You May Move 1 Piece You Own To A Adjacent Square";
            _firstclick = Position.NotAPosition;
            _secondclick = Position.NotAPosition;
        }

        public override bool IsPlayable(Game game)
        {
            if (game.Turn < MinimumTurn) return false;
            else { return true; }

        }

        public override bool Resolve(Game game)
        {
            bool result = false;
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_firstclick != Position.NotAPosition && _secondclick != Position.NotAPosition)
                {
                    _firstclick = Position.NotAPosition;
                    _secondclick = Position.NotAPosition;
                }
                if (_firstclick == Position.NotAPosition) _firstclick = HelperFunctions.PositionClicked();
                else if (_secondclick == Position.NotAPosition) _secondclick = HelperFunctions.PositionClicked();
                Piece first = null; 
                Piece second = null;
                if (_firstclick != Position.NotAPosition && _secondclick != Position.NotAPosition)
                {
                    first = game.Board.Find(_firstclick);
                    second = game.Board.Find(_secondclick);
                    if ((second.Owner == PlayerColour.NoOwner) && (first.Owner == Owner) && IsPlayable(game) && !_used) ;
                    {
                        game.Board.Remove(_firstclick);
                        game.Board.Add(_secondclick, first);
                        first.NewPosition(_secondclick);
                        result = true;
                        _used = true;
                    }
                }
            }
            return result;
        }
    }

    public class Matricide : Card
    {
        public Matricide(PlayerColour player) : base(20, player, "Matricide")
        {
            Description = "This card makes it so you need to check/checkmate the queen";
        }

        public override bool IsPlayable(Game game)
        {
            return game.Board.Contains(Kind.Queen, PlayerColour.White) && game.Board.Contains(Kind.Queen, PlayerColour.Black) && game.Turn >= MinimumTurn;
        }

        public override bool Resolve(Game game)
        {

            if (IsPlayable(game) && !_used)
            {
                game.Monarch = Kind.Queen;
                _used = true;
                return true;
            }
            return false;
        }
    }

    public class Swap : Card
    {
        Position _newclick;
        Position _secondclick;

        public Swap(PlayerColour player) : base(10, player, "Swap")
        {
            Description = "Swap Allows You To Swap The Positions Of Two Pieces You Control";
            _newclick = Position.NotAPosition;
            _secondclick = Position.NotAPosition;
        }
        public override bool IsPlayable(Game game)
        {
            if (game.Turn < MinimumTurn) return false;
            else { return true; }
        }

        public override bool Resolve(Game game)
        {

            bool result = false;
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_newclick != Position.NotAPosition && _secondclick != Position.NotAPosition)
                {
                    _newclick = Position.NotAPosition;
                    _secondclick = Position.NotAPosition;
                }
                if (_newclick == Position.NotAPosition) _newclick = HelperFunctions.PositionClicked();
                else if (_secondclick == Position.NotAPosition) _secondclick = HelperFunctions.PositionClicked();
                Piece first = game.Board.Find(_newclick);
                Piece second = game.Board.Find(_secondclick);
                if (first.Owner == Owner && second.Owner == Owner && IsPlayable(game) && !_used)
                {
                    game.Board.Remove(_newclick);
                    game.Board.Remove(_secondclick);
                    game.Board.Add(_newclick, second);
                    game.Board.Add(_secondclick, first);
                    first.NewPosition(_secondclick);
                    second.NewPosition(_newclick);
                    result = true;
                    _used = true;
                }
            }
            return result;
        }
    }

    public class PapalRenunciation : Card
    {
        public PapalRenunciation(int turn, PlayerColour player) : base(turn, player) { }
        public override bool IsPlayable(Game game)
        {
            return game.Turn >= MinimumTurn && game.Board.Contains(Kind.Bishop, Owner);
        }

        public override bool Resolve(Game game)
        {
            //give the owner a Papal Election card
            //turn all bishops into Cardinals
            return false;
        }
    }

    public class PapalElection : Card
    {
        public PapalElection(int turn, PlayerColour player) : base(turn, player) { }

        public override bool IsPlayable(Game game)
        {
            return game.Turn >= MinimumTurn; //&&
            //      game.Board.Count(Kind.Cardinal, Owner) 
            //      > game.Board.Count(Kind.Cardinal, HelperFunctions.GetOpponent(Owner))
        }

        public override bool Resolve(Game game)
        {
            //player selects a cardinal they own, it becomes a pope
            return false;
        }
    }

    /*******************************************************************************
     *  CARDS TO ADD
     * *****************************************************************************
     * 
     *  Killer Queen    : kills all friendly and enemy pieces around the queen
     *  Fortify         : builds an untakeable blocking piece next to a rook you control
     *  Kagemusha       : allows you to move your king 1 space (or no spaces) then creates a body double that looks and acts like a king piece
     *  Four Horsemen   : promotes a number of units until you have 4 knights
     *  Castle          : a card each player gets by default, it functions like the castle maneuver from normal chess
     *  Sidestep        : allows you to move any one piece 1 space before you make your move (or at the end of turn for balance if we can make that work)
     *  Matricide       : changes the rules so that the queen is the piece that needs to be taken in order to win
     *  Swap            : switches the position of any 2 pieces you control (also might need to be at the end of turn for balance)
     *  PapalRenunciation
     *                  : promotes all bishops to cardinals and gives user a PapalElection Card
     *  PapalElection   : if you have more cardinals, one of them becomes a pope
     */
}
