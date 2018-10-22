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
            switch (r.Next(9))
            {
                case 0:
                    return new KillerQueen(p);
                case 1:
                    return new Swap(p);
                case 2:
                    return new Sidestep(p);
                case 3:
                    return new Matricide(p);
                case 4:
                    return new FourHorsemen(p);
                case 5:
                   // return new KillPiece(p, r);
                case 6:
                    //return new Promote(p, r);
                case 7:
                    //return new Recruit(p, r);
                case 8:
                    //return new Demote(p, r);
                    break;
            }
            return null;
        }

    }
}
