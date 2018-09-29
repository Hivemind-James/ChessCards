using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract public class Card
    {
        public abstract bool IsPlayable(Game game);
        public abstract void Resolve(Game game);
        public abstract void DrawSmall();
        public abstract void DrawLarge();
    }
}
