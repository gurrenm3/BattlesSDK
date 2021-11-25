using System;

namespace BattlesSDK.Api
{
    /// <summary>
    /// The active user who's playing the game. I.E the Actual Player
    /// </summary>
    public class FriendlyPlayer : Player
    {
        /// <summary>
        /// Called whenever the player's cash is changed
        /// </summary>
        public BattlesEvent<int> CashChanged { get; private set; } = new BattlesEvent<int>();

        /// <summary>
        /// Called whenever the player's Eco is changed
        /// </summary>
        public BattlesEvent<int> EcoChanged { get; private set; } = new BattlesEvent<int>();


        /// <summary>
        /// Add to the player's current Health
        /// </summary>
        /// <param name="healthToAdd">amount of Health to add</param>
        public void AddHealth(int healthToAdd) => SetHealth(GetHealth() + healthToAdd);

        /// <summary>
        /// Take away from the player's current Health
        /// </summary>
        /// <param name="healthToRemove">amount of Health to remove</param>
        public void RemoveHealth(int healthToRemove) => SetHealth(GetHealth() - healthToRemove);

        /// <summary>
        /// Set the player's current Health
        /// </summary>
        /// <param name="newHealth">amount to set the Health to</param>
        private void SetHealth(int newHealth)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int GetHealth()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Add to the player's current Cash
        /// </summary>
        /// <param name="cashToAdd">amount of Cash to add</param>
        public void AddCash(int cashToAdd) => SetCash(GetCash() + cashToAdd);

        /// <summary>
        /// Take away from the player's current Cash
        /// </summary>
        /// <param name="cashToRemove">amount of Cash to remove</param>
        public void RemoveCash(int cashToRemove) => SetCash(GetCash() - cashToRemove);

        /// <summary>
        /// Set the player's current Cash
        /// </summary>
        /// <param name="newCash">amount to set the Cash to</param>
        private void SetCash(int newCash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the player's current Eco
        /// </summary>
        /// <returns></returns>
        public int GetCash()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add to the player's current Eco
        /// </summary>
        /// <param name="ecoToAdd">amount of Eco to add</param>
        public void AddEco(int ecoToAdd) => SetEco(GetEco() + ecoToAdd);

        /// <summary>
        /// Take away from the player's current Eco
        /// </summary>
        /// <param name="ecoToRemove">amount of Eco to remove</param>
        public void RemoveEco(int ecoToRemove) => SetEco(GetEco() - ecoToRemove);

        /// <summary>
        /// Set the player's current Eco
        /// </summary>
        /// <param name="newEco">amount to set the Eco to</param>
        private void SetEco(int newEco)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the player's current Eco
        /// </summary>
        /// <returns></returns>
        public int GetEco()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a tower model to your roster
        /// </summary>
        /// <param name="towerToAdd"></param>
        public void AddTowerToRoster(TowerModel towerToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
