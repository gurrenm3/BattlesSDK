using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattlesSDK.Api
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Running instance of the Game class
        /// </summary>
        public static Game Instance
        {
            get { return instance == null ? instance = new Game() : instance; }
            set { instance = value; }
        }
        private static Game instance;


        /// <summary>
        /// The name of the Game Window
        /// </summary>
        public const string WindowName = "Bloons TD Battles";

        /// <summary>
        /// Player1 instance
        /// </summary>
        public Player Player1 { get; private set; }

        /// <summary>
        /// Player2 instance
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// A pointer to the game's Process handle
        /// </summary>
        public IntPtr GameHandle { get; private set; } = IntPtr.Zero;

        /// <summary>
        /// Default constructor for <see cref="Game"/>
        /// </summary>
        public Game()
        {
            GameHandle = User32.FindWindow(null, WindowName);
        }

        /// <summary>
        /// Gets the screen dimensions of the game window.
        /// </summary>
        /// <remarks>If you want to get the screen dimensions of the computer screen, use <see cref="Screen.ScreenRect"/></remarks>
        public Rect GetGameRect()
        {
            User32.GetWindowRect(GameHandle, out var gameRect);
            gameRect.UpdateHeightAndWidth();
            return gameRect;
        }

        /// <summary>
        /// Gets the center position of the game window
        /// </summary>
        /// <returns></returns>
        /// <remarks>If you want to get the center position of the computer screen, use <see cref="Screen.CenterScreen"/></remarks>
        public Vector2 GetCenterScreen()
        {
            var gameRect = GetGameRect();
            return new Vector2(gameRect.Width / 2, gameRect.Height / 2);
        }



        #region Battles Events

        /// <summary>
        /// Called when you first join a game, but before round 1 starts
        /// </summary>
        public BattlesEvent GameStarted { get; private set; } = new BattlesEvent();

        /// <summary>
        /// Called whenever a new round starts
        /// </summary>
        public BattlesEvent<int> RoundStarted { get; private set; } = new BattlesEvent<int>();

        /// <summary>
        /// Called whenever a round ends
        /// </summary>
        public BattlesEvent<int> RoundEnded { get; private set; } = new BattlesEvent<int>();

        /// <summary>
        /// Called when you win a game
        /// </summary>
        public BattlesEvent Victory { get; private set; } = new BattlesEvent();

        /// <summary>
        /// Called when you lose a game
        /// </summary>
        public BattlesEvent Defeated { get; private set; } = new BattlesEvent();

        /// <summary>
        /// Called whenever you finish a game, whether or not you win
        /// </summary>
        public BattlesEvent GameFinished { get; private set; } = new BattlesEvent();

        #endregion
    }
}
