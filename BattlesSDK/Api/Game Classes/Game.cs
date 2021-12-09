using ModSDK.Api.Hooks;
using System;

namespace ModSDK.Api
{
    /// <summary>
    /// TODO
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// Mod event for game initialization. This event is called before the game initialization actually starts.
        /// </summary>
        public static ModEvent<GameStruct> OnGameStarting { get; set; } = new ModEvent<GameStruct>();

        /// <summary>
        /// Mod event for game initialization. This event is called after the game initialization finishes.
        /// </summary>
        public static ModEvent<GameStruct> OnGameStarted { get; set; } = new ModEvent<GameStruct>();


        /// <summary>
        /// The name of the Game Window.
        /// </summary>
        public const string WindowName = "Bloons TD Battles";

        /// <summary>
        /// The match that the player is currently in.
        /// </summary>
        public Match CurrentMatch { get; private set; }
    }
}
