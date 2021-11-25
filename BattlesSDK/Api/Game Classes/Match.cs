using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesSDK.Api
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
