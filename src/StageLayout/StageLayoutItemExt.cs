using MiscUtil.IO;
using OpenTK;
using System;

namespace LibGC.StageLayout
{
    /// <summary>
    /// Contains information to place a generic item in a stage.
    /// </summary>
    public class StageLayoutItemExt
    {
        /// <summary>
        /// Position of the item in the stage.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Rotation, for each component of the item. 0 to 1 indicates a full turn.
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Used for the spikes on ST38 of SMB. Those are moving spikes, so I believe this to be a
        /// reference to some animation element to signify that the collision box has to move too.
        /// </summary>
        ushort UnkAnimId;

        /// <summary>
        /// Scale factor for each component of the item.
        /// </summary>
        public Vector3 Scale { get; set; }

        public StageLayoutItemExt()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.Zero;
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
            UnkAnimId = input.ReadUInt16();
            Scale = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
        }
    }

}
