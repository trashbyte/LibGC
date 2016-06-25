using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.Lz
{
    /// <summary>
    /// Handles version-specific details in LZ streams.
    /// </summary>
    static class LzVersionDetails
    {
        public static bool IsHeaderIncludedInCompressedSizeField(GcGame game)
        {
            switch (game)
            {
                case GcGame.SuperMonkeyBall1:
                case GcGame.SuperMonkeyBall2:
                    return true;
                case GcGame.FZeroGX:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException("game");
            }
        }
    }
}
