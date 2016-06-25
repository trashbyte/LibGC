using MiscUtil.Conversion;
using MiscUtil.IO;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LibGC.StageLayout
{
    public class StageLayout
    {
        public Collection<StageLayoutCollision> Collision { get; private set; }

        public Collection<StageLayoutGoal> Goals { get; private set; }

        public Collection<StageLayoutItem> Bumpers { get; private set; }

        /// <summary>
        /// Those are the pistons that can push the ball and move according to the tilt.
        /// See the levels Advanced - Stage 24 (specially) and Advanced - Stage 35 on SMB for examples.
        /// </summary>
        public Collection<StageLayoutItem> Jamabars { get; private set; }

        public Collection<StageLayoutBanana> Bananas { get; private set; }

        /// <summary>
        /// Those contain the collision boxes of various scenary elements.
        /// </summary>
        public Collection<StageLayoutItemExt> Unk40 { get; private set; }

        // The big ball at st122
        public Collection<StageLayoutUnk48> Unk48 { get; private set; }

        // Some kind of plants?
        public Collection<StageLayoutUnk50> Unk50 { get; private set; }

        // Looks like some kind of bumper
        public Collection<StageLayoutUnk60> Unk60 { get; private set; }

        // Those seem to be used for various models
        public Collection<StageLayoutUnk70> Unk70 { get; private set; }

        public Collection<StageLayoutModelName> ModelNames { get; private set; }

        public StageLayout()
        {
            Collision = new NonNullableCollection<StageLayoutCollision>();
            Goals = new NonNullableCollection<StageLayoutGoal>();
            Bumpers = new NonNullableCollection<StageLayoutItem>();
            Jamabars = new NonNullableCollection<StageLayoutItem>();
            Bananas = new NonNullableCollection<StageLayoutBanana>();
            Unk40 = new NonNullableCollection<StageLayoutItemExt>();
            Unk48 = new NonNullableCollection<StageLayoutUnk48>();
            Unk50 = new NonNullableCollection<StageLayoutUnk50>();
            Unk60 = new NonNullableCollection<StageLayoutUnk60>();
            Unk70 = new NonNullableCollection<StageLayoutUnk70>();
            ModelNames = new NonNullableCollection<StageLayoutModelName>();
        }

        public StageLayout(Stream inputStream)
            : this()
        {
            if (inputStream == null)
                throw new ArgumentNullException("inputStream");

            Load(new EndianBinaryReader(EndianBitConverter.Big, inputStream));
        }

        private void Load(EndianBinaryReader input)
        {
            int unk0 = input.ReadInt32();
            int unk4 = input.ReadInt32();
            int numCollission = input.ReadInt32();
            int collisionOffset = input.ReadInt32();
            if (input.ReadInt32() != 0xA0)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x10] == 0xA0.");
            int unk14 = input.ReadInt32();
            int numGoals = input.ReadInt32();
            int goalsOffset = input.ReadInt32();
            if (input.ReadInt32() != numGoals)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x18] == StageLayout[0x20].");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x24] == 0.");
            int numBumbers = input.ReadInt32();
            int bumpersOffset = input.ReadInt32();
            int numJamabars = input.ReadInt32();
            int jamabarsOffset = input.ReadInt32();
            int numBananas = input.ReadInt32();
            int bananasOffset = input.ReadInt32();
            int numUnk40 = input.ReadInt32();
            int unk40Offset = input.ReadInt32();
            int numUnk48 = input.ReadInt32();
            int unk48Offset = input.ReadInt32();
            int numUnk50 = input.ReadInt32();
            int unk50Offset = input.ReadInt32();
            int numModelNames = input.ReadInt32();
            int modelNamesOffset = input.ReadInt32();
            // Looks like a number/offset to some struct of size 0x20, mostly floats
            int numUnk60 = input.ReadInt32();
            int unk60Offset = input.ReadInt32();
            int unk68 = input.ReadInt32();
            int unk6C = input.ReadInt32();
            int numUnk70 = input.ReadInt32();
            int unk70Offset = input.ReadInt32();
            int unk78 = input.ReadInt32();
            int unk7C = input.ReadInt32();
            int unk80 = input.ReadInt32();
            int unk84 = input.ReadInt32();
            int unk88 = input.ReadInt32();
            int unk8C = input.ReadInt32();
            int unk90 = input.ReadInt32();
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x94] == 0.");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x98] == 0.");
            if (input.ReadInt32() != 0)
                throw new InvalidStageLayoutFileException("Expected StageLayout[0x9C] == 0.");

            //if (numCollission != 0) Console.WriteLine(numCollission + "/" + collisionOffset);

            /*
            if (unk78 != 0)
            {
                input.BaseStream.Position = unk7C;
                for (int i = 0; i < unk78 + 5; i++)
                {
                    byte[] bytes = input.ReadBytes(0x38);
                    if (i >= unk78) Console.Write("XXX ");
                    Console.WriteLine(string.Join(" ", bytes.Select(b => b.ToString("X2"))));
                }

                Console.ReadKey();
            }
            */

            input.BaseStream.Position = collisionOffset;
            for (int i = 0; i < numCollission; i++)
            {
                StageLayoutCollision collision = new StageLayoutCollision();
                collision.Load(input);
                Collision.Add(collision);
            }

            input.BaseStream.Position = modelNamesOffset;
            for (int i = 0; i < numModelNames; i++)
            {
                StageLayoutModelName modelName = new StageLayoutModelName();
                modelName.Load(input);
                ModelNames.Add(modelName);
            }

            input.BaseStream.Position = goalsOffset;
            for (int i = 0; i < numGoals; i++)
            {
                StageLayoutGoal goal = new StageLayoutGoal();
                goal.Load(input);
                Goals.Add(goal);
            }

            input.BaseStream.Position = bumpersOffset;
            for (int i = 0; i < numBumbers; i++)
            {
                StageLayoutItem bumper = new StageLayoutItem();
                bumper.Load(input);
                Bumpers.Add(bumper);
            }

            input.BaseStream.Position = jamabarsOffset;
            for (int i = 0; i < numJamabars; i++)
            {
                StageLayoutItem jamabar = new StageLayoutItem();
                jamabar.Load(input);
                Jamabars.Add(jamabar);
            }

            input.BaseStream.Position = bananasOffset;
            for (int i = 0; i < numBananas; i++)
            {
                StageLayoutBanana banana = new StageLayoutBanana();
                banana.Load(input);
                Bananas.Add(banana);
            }

            input.BaseStream.Position = unk40Offset;
            for (int i = 0; i < numUnk40; i++)
            {
                StageLayoutItemExt unk40 = new StageLayoutItemExt();
                unk40.Load(input);
                Unk40.Add(unk40);
            }

            input.BaseStream.Position = unk48Offset;
            for (int i = 0; i < numUnk48; i++)
            {
                StageLayoutUnk48 unk48 = new StageLayoutUnk48();
                unk48.Load(input);
                Unk48.Add(unk48);
            }

            input.BaseStream.Position = unk50Offset;
            for (int i = 0; i < numUnk50; i++)
            {
                StageLayoutUnk50 unk50 = new StageLayoutUnk50();
                unk50.Load(input);
                Unk50.Add(unk50);
            }

            input.BaseStream.Position = unk60Offset;
            for (int i = 0; i < numUnk60; i++)
            {
                StageLayoutUnk60 unk60 = new StageLayoutUnk60();
                unk60.Load(input);
                Unk60.Add(unk60);
            }

            input.BaseStream.Position = unk70Offset;
            for (int i = 0; i < numUnk70; i++)
            {
                StageLayoutUnk70 unk70 = new StageLayoutUnk70();
                unk70.Load(input);
                Unk70.Add(unk70);
            }

        }

        /*
--LZ FORMAT--
 File header (0xA0 bytes):

 00 ## ## ## ## - ??? (Usually 00 00 00 01)
 04 ## ## ## ## - ??? (Usually 00 00 00 64)
 08 ## ## ## ## - COLLISION
 0C ## ## ## ## - OFFSET 1
 10 00 00 00 A0 ## ## ## ## - ALWAYS (# Usually 000000B4)
 18 ## ## ## ## - NO. GOALS???
 1C ## ## ## ## - OFFSET 2
 20 ## ## ## ## - NO. GOALS???
 24 00 00 00 00 - ALWAYS
 28 ## ## ## ## - BUMPERS
 2C ## ## ## ## - OFFSET 3
 30 ## ## ## ## - NO. JAMABARS (SEE AD14 AND AD25)
 34 ## ## ## ## - OFFSET
 38 ## ## ## ## - BANANAS
 3C ## ## ## ## - OFFSET 4
 40 00 00 00 00 00 00 00 00 - ALWAYS
 48 00 00 00 00 00 00 00 00 - ALWAYS
 50 ## ## ## ## - NO. SOMETHING
 54 ## ## ## ## - OFFSET 5
 58 ## ## ## ## - LEVEL MODELS
 5C ## ## ## ## - OFFSET 6
 60 00 00 00 00 00 00 00 00 - ALWAYS
 68 ## ## ## ## - MODELS
 6C ## ## ## ## - OFFSET 7
 70 ## ## ## ## - NO. SOMETHING
 74 ## ## ## ## - OFFSET
 78 ## ## ## ## ## ## ## ## - ???
 80 ## ## ## ## - REFLECTION FLAG?
 84 ## ## ## ## - OFFSET 8
 88 00 00 00 00 00 00 00 00 - ALWAYS
 90 00 00 00 00 00 00 00 00 - ALWAYS
 98 00 00 00 00 00 00 00 00 - ALWAYS



 Collision header:

 0x18 zero bytes
 ## ## ## ## - Size of this header minus 0x0C? (Usually 000000B8)
 ## ## ## ## - Start of collision triangle data
 ## ## ## ## - Start of pointers to triangle indices (4 bytes each, 256 of these) (Triangle indices are 2 bytes, lists terminated by FFFF)
 ## ## ## ## - Some float
 ## ## ## ## - Some float
 ## ## ## ## - Some float
 ## ## ## ## - Some float
 0x90 near copy of file header, starts with 00 00 00 10 00 00 00 10,
 then continues at 0x18 from file header. Sometimes longer?



 GOAL FORMAT:
 XX XX XX XX - X POSITION (FLOAT)
 YY YY YY YY - Y POSITION (FLOAT)
 ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
 XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
 YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
 ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
 CC CC - GOAL COLOR (4200 IS BLUE, 4700 IS GREEN, 5200 IS RED)

 JAMABAR FORMAT:
 XX XX XX XX - X POSITION (FLOAT)
 YY YY YY YY - Y POSITION (FLOAT)
 ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
 XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
 YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
 ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
 00 00 - ALWAYS 0
 XX XX XX XX - X SCALE (FLOAT)
 YY YY YY YY - Y SCALE (FLOAT)
 ZZ ZZ ZZ ZZ - Z SCALE (FLOAT)

 BUMPER FORMAT:
 XX XX XX XX - X POSITION (FLOAT)
 YY YY YY YY - Y POSITION (FLOAT)
 ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
 XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
 YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
 ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
 00 00 - ALWAYS 0
 XX XX XX XX - X SCALE (FLOAT)
 YY YY YY YY - Y SCALE (FLOAT)
 ZZ ZZ ZZ ZZ - Z SCALE (FLOAT)

 BANANA FORMAT:
 XX XX XX XX - X POSITION (FLOAT)
 YY YY YY YY - Y POSITION (FLOAT)
 ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
 TT TT TT TT - TYPE OF BANANA (00000000 SINGLE, 00000001 BUNCH)

 MODEL FORMAT:
 UNKNOWN, SEEMS TO BE SOME KIND OF TREE/HIERARCHY



 COLLISION TRIANGLE FORMAT

 (ROTATION IS Z THEN X THEN Y)

 04 X1
 04 Y1
 04 Z1
 04 Normal X
 04 Normal Y
 04 Normal Z
 02 X Angle
 02 Y Angle
 02 Z Angle
 02 Zero
 04 DX2X1
 04 DY2Y1
 04 DX3X1
 04 DY3Y1
 04 ?
 04 ?
 04 ?
 04 ?
         * */
    }
}
