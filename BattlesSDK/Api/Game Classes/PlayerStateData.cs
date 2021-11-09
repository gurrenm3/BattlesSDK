namespace BattlesSDK.Api
{
    /// <summary>
    /// Contains info about the Player
    /// </summary>
    public class PlayerStateData
    {
        /// <summary>
        /// Player's current Health
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Player's current Units
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Player's current Nanites
        /// </summary>
        public int Nanites { get; set; }

        /// <summary>
        /// Player's current QuickSilver
        /// </summary>
        public int Quicksilver { get; set; }
    }
}
