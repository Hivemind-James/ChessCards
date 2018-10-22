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
        private int _minTurn;
        private PlayerColour _owner;
        private string _name;
        private string _description;

        protected float _smallWidth;
        protected float _smallHeight;
        protected float _largeWidth;
        protected float _largeHeight;

       
        public Card(int turn, PlayerColour player, string name) : this (turn, player)
        {
            _name = name;
        }
        public Card(int turn, PlayerColour player)
        {
            _minTurn = turn;
            _owner = player;

            _smallWidth = 80;
            _smallHeight = 120;
            _largeWidth = 250;
            _largeHeight = 350;
        }

        public abstract bool IsPlayable(Game game);
        public abstract bool Resolve(Game game);
        public virtual void DrawSmall(int count)
        {
            SwinGame.DrawRectangle(Color.Black, (count * _smallWidth), SwinGame.ScreenHeight() - _smallHeight, _smallWidth, _smallHeight);
            SwinGame.DrawText(_name, Color.Black, (count * _smallWidth), SwinGame.ScreenHeight() - _smallHeight);
        }
        public virtual void DrawLarge(int x, int y)
        {
            SwinGame.DrawRectangle(Color.Black, x, y, _largeWidth, _largeHeight);
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
    }

    public class KillPiece : Card
    {
        private Kind _target;
        private PlayerColour _enemy;
        private Position _selection;

        public KillPiece(Kind kind, PlayerColour owner, int turn) : base(turn, owner)
        {
            _target = kind;
            _enemy = (owner == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;
            _selection = Position.NotAPosition;
        }

        public override bool IsPlayable(Game game)
        {
            return game.Board.Contains(_target, _enemy) && game.Turn >= MinimumTurn;
        }

        public override bool Resolve(Game game)
        {
            Position temp;
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                temp = HelperFunctions.PositionClicked();
                if (_selection == temp) game.Board.Remove(_selection);
                else _selection = temp; 
            }
            return false;
        }
    }

    public class Promote : Card
    {
        private List<Kind> _targets;
        private List<Kind> _promoOptions;

        public Promote (int turn, PlayerColour owner, List<Kind> targets, List<Kind> promotionOptions) : base(turn, owner)
        {
            _targets = targets;
            _promoOptions = promotionOptions;
        }

        public override bool IsPlayable(Game game)
        {
            bool isPlayable = false;
            foreach (Kind target in _targets)
            {
                isPlayable = game.Board.Contains(target, Owner) && game.Turn >= MinimumTurn;
                if (isPlayable) break;
            }
            return isPlayable;
        }

        public override bool Resolve(Game game)
        {
            //if (_promoOptions.Contains(Kind.Queen) && game.Board.Contains(Kind.Queen, Owner)); //Player can't choose queen
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
        public KillerQueen(int turn, PlayerColour player) : base(turn, player, "Killer Queen"){}

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
            return false;
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
        public FourHorsemen(int turn, PlayerColour player) : base(turn, player)
        { }

        public override bool IsPlayable(Game game)
        {
            return  game.Turn >= MinimumTurn &&
                    game.Board.Count(Kind.Knight, Owner) < 4 &&
                    game.Board.Count(Owner) > 4;
        }

        public override bool Resolve(Game game)
        {
            while (game.Board.Count(Kind.Knight, Owner) < 4)
            {
                //promote piece to Knight
            }
            return false;
        }
    }

    public class Castle : Card
    {
        List<Rook> _rooks;

        public Castle(int turn, PlayerColour owner) : base(turn, owner)
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
        public Sidestep(int turn, PlayerColour player) : base(turn, player) { }

        public override bool IsPlayable(Game game)
        {
            return false;
        }

        public override bool Resolve(Game game)
        {
            return false;
        }
    }

    public class Matricide : Card
    {
        public Matricide(int turn, PlayerColour player) : base(turn, player) { }

        public override bool IsPlayable(Game game)
        {
            return game.Board.Contains(Kind.Queen, PlayerColour.White) && game.Board.Contains(Kind.Queen, PlayerColour.Black) && game.Turn >= MinimumTurn;
        }

        public override bool Resolve(Game game)
        {
            //game.ImportantPiece = Kind.Queen;
            return false;
        }
    }

    public class Swap : Card
    {
        public Swap(int turn, PlayerColour player) : base(turn, player) { }
        public override bool IsPlayable(Game game)
        {
            return false;
        }

        public override bool Resolve(Game game)
        {
            return false;
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
