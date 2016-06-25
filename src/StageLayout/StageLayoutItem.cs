using MiscUtil.IO;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibGC.StageLayout
{
    /// <summary>
    /// Contains information to place a generic item in a stage.
    /// </summary>
    public class StageLayoutItem
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
        /// Scale factor for each component of the item.
        /// </summary>
        public Vector3 Scale { get; set; }

        public StageLayoutItem()
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
            if (input.ReadUInt16() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayoutItem[0x12] == 0");
            Scale = new Vector3(input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
        }
    }
}
