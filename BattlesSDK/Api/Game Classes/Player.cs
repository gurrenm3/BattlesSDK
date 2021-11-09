using System.Collections.Generic;

namespace BattlesSDK.Api
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        public BattlesEvent<int, int> HealthChanged { get; private set; } = new BattlesEvent<int, int>();

        /// <summary>
        /// 
        /// </summary>
        public List<TowerModel> SelectedTowers { get; private set; } = new List<TowerModel>();
    }
}
