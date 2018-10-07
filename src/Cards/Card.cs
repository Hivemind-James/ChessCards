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

        public Card(int turn, PlayerColour player)
        {
            _minTurn = turn;
            _owner = player;
        }

        public abstract bool IsPlayable(Game game);
        public abstract void Resolve(Game game);
        public abstract void DrawSmall();
        public abstract void DrawLarge();

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
    }

    public class KillPiece : Card
    {
        private Kind _target;
        private PlayerColour _enemy;

        public KillPiece(Kind kind, PlayerColour owner, int turn) : base(turn, owner)
        {
            _target = kind;
            _enemy = (owner == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;
        }

        public override void DrawLarge()
        {
            throw new NotImplementedException();
        }

        public override void DrawSmall()
        {
            throw new NotImplementedException();
        }

        public override bool IsPlayable(Game game)
        {
            return game.Board.Contains(_target, _enemy) && game.Turn >= MinimumTurn;
        }

        public override void Resolve(Game game)
        {
            bool _resolving = true;
            while (_resolving)
            {
                SwinGame.ProcessEvents();
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    //Get Position (Input.MousePosition)
                }
            }
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

        public override void DrawLarge()
        {
            throw new NotImplementedException();
        }

        public override void DrawSmall()
        {
            throw new NotImplementedException();
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

        public override void Resolve(Game game)
        {
            //if (_promoOptions.Contains(Kind.Queen) && game.Board.Contains(Kind.Queen, Owner)); //Player can't choose queen
            throw new NotImplementedException();
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

        public override void DrawLarge()
        {
            throw new NotImplementedException();
        }

        public override void DrawSmall()
        {
            throw new NotImplementedException();
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

        public override void Resolve(Game game)
        {
            throw new NotImplementedException();
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
     *  ???             : promotes all your non-king pieces to body doubles
     *  Castle          : a card each player gets by default, it functions like the castle maneuver from normal chess
     *  Sidestep        : allows you to move any one piece 1 space before you make your move (or at the end of turn for balance if we can make that work)
     *  Matricide       : changes the rules so that the queen is the piece that needs to be taken in order to win
     *  Divine intervention
     *                  : switches the position of any piece with a bishop you control (also might need to be at the end of turn for balance)
     * 
     */
}
