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
    /// Contains information to place a goal in a stage.
    /// </summary>
    public class StageLayoutGoal
    {
        /// <summary>
        /// Possible colors of the goal.
        /// </summary>
        public enum GoalColor : ushort
        {
            Blue = 0x4200,
            Green = 0x4700,
            Red = 0x5200
        };

        /// <summary>
        /// Position of the goal in the stage.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Rotation, for each component of the goal. 0 to 1 indicates a full turn.
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Color of the goal.
        /// </summary>
        public GoalColor Color { get; set; }

        public StageLayoutGoal()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Color = GoalColor.Blue;
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

            ushort goalColorInt = input.ReadUInt16();
            if (!Enum.IsDefined(typeof(GoalColor), goalColorInt))
                throw new InvalidStageLayoutFileException("Unknown StageLayoutGoal[0x12].");
            Color = (GoalColor)goalColorInt;
        }
    }
}
