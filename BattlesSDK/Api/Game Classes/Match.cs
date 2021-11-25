using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModSDK.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Player1 instance.
        /// </summary>
        public FriendlyPlayer ActualPlayer { get; private set; }

        /// <summary>
        /// Instance of the current opponent.
        /// </summary>
        public EnemyPlayer Opponent { get; private set; }
        
        /// <summary>
        /// Default constructor for Match.
        /// </summary>
        public Match()
        {

        }

        /// <summary>
        /// Get the current round number
        /// </summary>
        /// <returns></returns>
        public int GetRoundNumber()
        {
            throw new NotImplementedException();
        }


        #region Battles Events

        /// <summary>
        /// Called when you first join a game, but before round 1 starts
        /// </summary>
        public ModEvent GameStarted { get; private set; } = new ModEvent();

        /// <summary>
        /// Called whenever a new round starts
        /// </summary>
        public ModEvent<int> RoundStarted { get; private set; } = new ModEvent<int>();

        /// <summary>
        /// Called whenever a round ends
        /// </summary>
        public ModEvent<int> RoundEnded { get; private set; } = new ModEvent<int>();

        /// <summary>
        /// Called when you win a game
        /// </summary>
        public ModEvent Victory { get; private set; } = new ModEvent();

        /// <summary>
        /// Called when you lose a game
        /// </summary>
        public ModEvent Defeated { get; private set; } = new ModEvent();

        /// <summary>
        /// Called whenever you finish a game, whether or not you win
        /// </summary>
        public ModEvent GameFinished { get; private set; } = new ModEvent();

        #endregion
    }
}
