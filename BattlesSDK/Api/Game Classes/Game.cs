using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesSDK.Api
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Game
    {
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


        /// <summary>
        /// Running instance of the Game class
        /// </summary>
        public static Game Instance { get; private set; }

        /// <summary>
        /// Player1 instance
        /// </summary>
        public Player Player1 { get; private set; }

        /// <summary>
        /// Player2 instance
        /// </summary>
        public Player Player2 { get; private set; }

        /// <summary>
        /// Default constructor for <see cref="Game"/>
        /// </summary>
        public Game()
        {
            if (Instance == null) 
                Instance = this;


        }
    }
}
