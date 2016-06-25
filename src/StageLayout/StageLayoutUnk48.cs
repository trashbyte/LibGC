using MiscUtil.IO;
using OpenTK;
using System;

namespace LibGC.StageLayout
{

    public class StageLayoutUnk48
    {
        public Vector3 Position { get; set; }
        public float Unk0C { get; set; }
        public float Unk10 { get; set; }

        public StageLayoutUnk48()
        {
            Position = Vector3.Zero;
            Unk0C = 0.0f;
            Unk10 = 0.0f;
        }

        internal void Load(EndianBinaryReader input)
        {
            Position = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
            Unk0C = input.ReadSingle();
            Unk10 = input.ReadSingle();
        }
    }
}
