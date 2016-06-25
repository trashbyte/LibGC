using MiscUtil.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.StageLayout
{
    public class StageLayoutModelName
    {
        public int Unk0 { get; set; } // Always 1 or 5. 1 is normal, 5 is MOT_REF_... name
        public string Name { get; set; }

        public StageLayoutModelName()
        {
            Name = null;
        }

        internal void Load(EndianBinaryReader input)
        {
            Unk0 = input.ReadInt32();
            int nameOffset = input.ReadInt32();
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutModelName[0x0C] == 0");

            long oldOffset = input.BaseStream.Position;
            input.BaseStream.Position = nameOffset;
            string name = input.ReadAsciiString();
            input.BaseStream.Position = oldOffset;
        }
    }
}
