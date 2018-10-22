using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public static class CardGenerator
    {

        public static Card GenerateCard(Random r, PlayerColour p)
        {
            switch (r.Next(100))
            {
                case int n when n>=0 && n<3:
                    return new KillerQueen(p);
                case int n when n>=3 && n<15:
                    return new Swap(p);
                case int n when n>=16 && n<25:
                    return new Sidestep(p);
                case int n when n>=25 && n<30:
                    return new Matricide(p);
                case int n when n>=30 && n<35:
                    return new FourHorsemen(p);
                case int n when n>=35 && n<70:
                    return new KillPiece(p, r);
                case int n when n>=70:
                    return new Promote(p, r);
            }
            return null;
        }

    }
}
