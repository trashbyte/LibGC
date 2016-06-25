using System.ComponentModel;

namespace LibGC
{
	/// <summary>
	/// Defines the different games supported by this library.
	/// Some functions in this library require the game specification
	/// in order to handle game-specific differences.
	/// </summary>
	public enum GcGame
	{
        /// <summary>Super Monkey Ball 1</summary>
        [Description("Super Monkey Ball 1")]
        SuperMonkeyBall1,
        /// <summary>Super Monkey Ball 2</summary>
        [Description("Super Monkey Ball 2")]
        SuperMonkeyBall2,
		/// <summary>F-Zero GX</summary>
        [Description("F-Zero GX")]
		FZeroGX
	}
}

