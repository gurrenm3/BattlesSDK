using System;

namespace BattlesSDK.Api
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Running instance of the Game class.
        /// </summary>
        public static Game Instance
        {
            get { return instance == null ? instance = new Game() : instance; }
            set { instance = value; }
        }
        private static Game instance;


        /// <summary>
        /// The name of the Game Window.
        /// </summary>
        public const string WindowName = "Bloons TD Battles";

        /// <summary>
        /// The match that the player is currently in.
        /// </summary>
        public Match CurrentMatch { get; private set; }

        /// <summary>
        /// A pointer to the game's Process handle.
        /// </summary>
        public IntPtr GameHandle { get; private set; } = IntPtr.Zero;

        /// <summary>
        /// Default constructor for <see cref="Game"/>.
        /// </summary>
        public Game()
        {
            GameHandle = User32.FindWindow(null, WindowName);
        }

        /// <summary>
        /// Gets the screen dimensions of the game window.
        /// </summary>
        /// <remarks>If you want to get the screen dimensions of the computer screen, use <see cref="Screen.ScreenRect"/>.</remarks>
        public Rect GetGameRect()
        {
            User32.GetWindowRect(GameHandle, out var gameRect);
            gameRect.UpdateHeightAndWidth();
            return gameRect;
        }

        /// <summary>
        /// Gets the center position of the game window.
        /// </summary>
        /// <returns></returns>
        /// <remarks>If you want to get the center position of the computer screen, use <see cref="Screen.CenterScreen"/>.</remarks>
        public Vector2 GetCenterScreen()
        {
            var gameRect = GetGameRect();
            return new Vector2(gameRect.Width / 2, gameRect.Height / 2);
        }
    }
}
