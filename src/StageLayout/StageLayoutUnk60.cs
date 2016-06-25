using MiscUtil.IO;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGC.StageLayout
{
    public class StageLayoutUnk60
    {
        public Vector3 Position { get; set; }
        public float Unk0C { get; set; }
        public float Unk10 { get; set; } // I think that this is the scale
        public float Unk14 { get; set; }
        public float Unk18 { get; set; }
        public float Unk1C { get; set; }

        public StageLayoutUnk60()
        {
            Position = Vector3.Zero;
            Unk0C = 0.0f;
            Unk10 = 0.0f;
            Unk14 = 0.0f;
            Unk18 = 0.0f;
            Unk1C = 0.0f;
        }

        internal void Load(EndianBinaryReader input)
        {
            Position = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
            Unk0C = input.ReadSingle();
            Unk10 = input.ReadSingle();
            Unk14 = input.ReadSingle();
            Unk18 = input.ReadSingle();
            Unk1C = input.ReadSingle();
        }
    }
}
