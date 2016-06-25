using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.Tpl
{
    /// <summary>
    /// Version-specific information for TPL textures.
    /// </summary>
    static class TplVersionDetails
    {
        /// <summary>
        /// If true, then the CMPR bug (see the format documentation) is replicated
        /// when writing the Tpl texture container to a stream, in order to be able
        /// to replicate perfectly the original game files.
        /// </summary>
        /// <param name="game">The game where this feature must be tested.</param>
        /// <returns>trye to replicate the CMPR bug, false otherwise.</returns>
        public static bool HasCmprSizeBug(GcGame game)
        {
            switch (game)
            {
                // Super Monkey Ball 1 doesn't have the CMPR bug
                case GcGame.SuperMonkeyBall1:
                    return false;
                // Super Monkey Ball 2 is a mess and some files have the CMPR bug and some don't
                // Return false here since it's "safer" to write the texture buffer with the correct (bigger) size
                case GcGame.SuperMonkeyBall2:
                    return false;
                // All F-Zero GX files have the CMPR bug consistently
                case GcGame.FZeroGX:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("game");
            }
        }

        /// <summary>
        /// If true, then, while reading, the size of the texture buffer is compared against the
        /// calculated (expected) size of the texture buffer, and if the validation fails, an
        /// exception is thrown.
        /// </summary>
        /// <param name="game">The game where this feature must be tested.</param>
        /// <returns>true to verify the size of the texture buffer while reading, false otherwise.</returns>
        public static bool VerifyCorrectSize(GcGame game)
        {
            switch (game)
            {
                // SMB1 has just one defective file with the incorrect texture buffer size,
                // but it forces us to disable the check in order to load all files correctly
                case GcGame.SuperMonkeyBall1:
                    return false;
                // SMB2 is a mess and many texture buffers don't have the correct size
                case GcGame.SuperMonkeyBall2:
                    return false;
                // F-Zero GX, even though it has the CMPR bug, has all texture buffer sizes
                // consistently following a pattern.
                case GcGame.FZeroGX:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("game");
            }
        }
    }
}
