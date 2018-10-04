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
}
