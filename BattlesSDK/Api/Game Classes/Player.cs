using System.Collections.Generic;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Base class for all Players
    /// </summary>
    public abstract class Player
    {
        /// <summary>
        /// Called whenever the player's health is changed
        /// </summary>
        public BattlesEvent<int> HealthChanged { get; private set; } = new BattlesEvent<int>();

        /// <summary>
        /// The towers that the player is using
        /// </summary>
        public List<TowerModel> SelectedTowers { get; private set; } = new List<TowerModel>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Get the player's current health
        /// </summary>
        /// <returns></returns>
        public abstract int GetHealth();
    }
}
