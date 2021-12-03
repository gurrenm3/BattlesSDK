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
        /// The name of the Game Window.
        /// </summary>
        public const string WindowName = "Bloons TD Battles";

        /// <summary>
        /// The match that the player is currently in.
        /// </summary>
        public Match CurrentMatch { get; private set; }
    }
}
