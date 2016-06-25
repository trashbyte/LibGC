using MiscUtil.IO;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.StageLayout
{
    public class StageLayoutUnk70
    {
        public int Unk00 { get; set; }
        public int Unk04 { get; set; }
        public float Unk0C { get; set; }

        /// <summary>
        /// Position of the item in the stage.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Rotation, for each component of the item. 0 to 1 indicates a full turn.
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Scale factor for each component of the item.
        /// </summary>
        public Vector3 Scale { get; set; }
        public int Unk30 { get; set; }
        public int Unk34 { get; set; }

        public StageLayoutUnk70()
        {
            Unk00 = 0;
            Unk04 = 0;
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.Zero;
            Unk30 = 0;
            Unk34 = 0;
        }

        internal void Load(EndianBinaryReader input)
        {
            Unk00 = input.ReadInt32(); // not offset
            Unk04 = input.ReadInt32(); // maybe offset
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutUnk70[0x08] == 0");

            Position = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
            // The rotation is stored as a 16-bit unsigned integer, where the full range
            // represents a full rotation
            Rotation = new Vector3(
                (float)input.ReadUInt16() / 0x10000,
                (float)input.ReadUInt16() / 0x10000,
                (float)input.ReadUInt16() / 0x10000);
            if (input.ReadUInt16() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutItem[0x12] == 0");
            Scale = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutUnk70[0x2C] == 0");
            Unk30 = input.ReadInt32(); // don't think it's offset but maybe
            Unk34 = input.ReadInt32(); // maybe offset
        }
    }
}
