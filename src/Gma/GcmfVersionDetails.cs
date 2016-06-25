using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.Gma
{
    static class GcmfVersionDetails
    {
        public static bool IsGcmfSkinModelSupported(GcGame game)
        {
            switch (game)
            {
                case GcGame.SuperMonkeyBall1:
                    return false;
                case GcGame.SuperMonkeyBall2:
                case GcGame.FZeroGX:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("game");
            }
        }

        public static bool Is16BitEffectiveModelIgnored(GcGame game)
        {
            switch (game)
            {
                case GcGame.SuperMonkeyBall1:
                    return true;
                case GcGame.SuperMonkeyBall2:
                case GcGame.FZeroGX:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException("game");
            }
        }
    }
}
