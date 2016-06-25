using MiscUtil.IO;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.StageLayout
{
    public class StageLayoutCollision
    {
        /// <summary>
        /// Position of the item in the stage.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Rotation, for each component of the item. 0 to 1 indicates a full turn.
        /// </summary>
        public Vector3 Rotation { get; set; }

        public ushort Unk12;

        public int Unk14;
        public int Unk18;
        public int Unk1C;
        public int Unk20;

        public float Unk24;
        public float Unk28;
        public float Unk2C;
        public float Unk30;

        public int Unk34;
        public int Unk38;

        public int Unk3C;
        public int Unk40;

        public int Unk4C;
        public int Unk50;
        public int Unk54;
        public int Unk58;
        public int Unk5C;
        public int Unk60;
        public int Unk64;
        public int Unk68;
        public int Unk6C;
        public int Unk70;
        public int Unk74;
        public int Unk78;
        public int Unk7C;
        public int Unk80;
        public int Unk84;
        public int Unk88;
        public int Unk8C;
        public int Unk90;
        public float UnkBC;
        public float UnkC0;

        public StageLayoutCollision()
        {
        }

        internal void Load(EndianBinaryReader input)
        {
            Position = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
            // The rotation is stored as a 16-bit unsigned integer, where the full range
            // represents a full rotation
            Rotation = new Vector3(
                (float)input.ReadUInt16() / 0x10000,
                (float)input.ReadUInt16() / 0x10000,
                (float)input.ReadUInt16() / 0x10000);
            Unk12 = input.ReadUInt16();
            Unk14 = input.ReadInt32(); // Looks like offset
            Unk18 = input.ReadInt32(); // Looks like offset
            Unk1C = input.ReadInt32(); // Looks like offset
            Unk20 = input.ReadInt32(); // Looks like offset

            Unk24 = input.ReadSingle();
            Unk28 = input.ReadSingle();
            Unk2C = input.ReadSingle();
            Unk30 = input.ReadSingle();

            Unk34 = input.ReadInt32(); // Not offset
            Unk38 = input.ReadInt32(); // Not offset

            Unk3C = input.ReadInt32(); // Not offset
            Unk40 = input.ReadInt32(); // Probably offset
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0x44] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0x48] == 0");
            Unk4C = input.ReadInt32(); // Not offset
            Unk50 = input.ReadInt32(); // Probably offset
            Unk54 = input.ReadInt32(); // Not offset
            Unk58 = input.ReadInt32(); // Probably offset
            Unk5C = input.ReadInt32(); // Not offset
            Unk60 = input.ReadInt32(); // Probably offset
            Unk64 = input.ReadInt32(); // Not offset
            Unk68 = input.ReadInt32(); // Probably offset
            Unk6C = input.ReadInt32(); // Not offset
            Unk70 = input.ReadInt32(); // Probably offset
            Unk74 = input.ReadInt32(); // Not offset
            Unk78 = input.ReadInt32(); // Probably offset
            Unk7C = input.ReadInt32(); // Not offset
            Unk80 = input.ReadInt32(); // Probably offset
            Unk84 = input.ReadInt32(); // Not offset
            Unk88 = input.ReadInt32(); // Probably offset
            Unk8C = input.ReadInt32(); // Not offset
            Unk90 = input.ReadInt32(); // Probably offset
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0x94] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0x98] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0x9C] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xA0] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xA4] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xA8] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xAC] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xB0] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xB4] == 0");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutCollision[0xB8] == 0");
            UnkBC = input.ReadSingle();
            UnkC0 = input.ReadSingle();

            long oldOffset = input.BaseStream.Position;
            input.BaseStream.Position = Unk14;
            Console.WriteLine(Unk14.ToString("X8"));
            if (Unk14 != 0) Console.ReadKey();
            input.BaseStream.Position = oldOffset;
        }
    }
}
