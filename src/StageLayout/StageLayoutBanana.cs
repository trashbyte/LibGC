using MiscUtil.IO;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.StageLayout
{
    /// <summary>
    /// Contains information to place a banana or banana bunch in a stage.
    /// </summary>
    public class StageLayoutBanana
    {
        /// <summary>
        /// Possible kinds of banana (single banana or bunch of bananas).
        /// </summary>
        public enum BananaType : int
        {
            Single = 0,
            Bunch = 1
        };

        /// <summary>
        /// The position of the banana.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The kind of the banana.
        /// </summary>
        public BananaType Type { get; set; }

        public StageLayoutBanana()
        {
            Position = Vector3.Zero;
            Type = BananaType.Single;
        }

        internal void Load(EndianBinaryReader input)
        {
            Position = new Vector3(
                input.ReadSingle(),
                input.ReadSingle(),
                input.ReadSingle());

            int bananaTypeInt = input.ReadInt32();
            if (!Enum.IsDefined(typeof(BananaType), bananaTypeInt))
                throw new InvalidStageLayoutFileException("Unknown StageLayoutBanana[0x0C].");
            Type = (BananaType)bananaTypeInt;
        }
    }
}
