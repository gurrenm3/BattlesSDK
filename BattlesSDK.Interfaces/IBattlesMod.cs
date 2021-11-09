using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Diagnostics;

namespace BattlesSDK.Interfaces
{
    /// <summary>
    /// Parent interface for all Battles mods.
    /// </summary>
    public interface IBattlesMod
    {
        /// <summary>
        /// The running Process for Battles.
        /// </summary>
        Process BattlesProcess { get; set; }

        /// <summary>
        /// Info about this mod, such as the ModName, ModId, ModDescription, etc.
        /// </summary>
        IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// A BattlesLogger for this mod.
        /// </summary>
        IBattlesLogger Logger { get; set; }

        /// <summary>
        /// The ModLoader instance.
        /// </summary>
        IModLoader ModLoader { get; set; }

        /// <summary>
        /// [Battles Event] Called once when this mod is loaded.
        /// <br/>This happens when this mod is Registered by <see cref="IBattlesController"/>.
        /// </summary>
        void Start();

        /// <summary>
        /// [Battles Event] Called once every tick.
        /// </summary>
        /// <remarks>This is a pseudo-Update method. Not actually synced to Battles's tick.</remarks>
        void Update();

        /// <summary>
        /// [Battles Event] Called when a mod is unregistered from the BattlesController.
        /// <br/>Currently this will only be called if you choose to unregister your mod from the API.
        /// </summary>
        void OnModUnregistered();

        /// <summary>
        /// [Battles Event] Called when the game is closed.
        /// </summary>
        void OnGameExit();
    }
}