using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK.Interfaces
{
    /// <summary>
    /// Parent class for all Battles mods
    /// </summary>
    public interface IBattlesMod
    {
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
        /// Called once when the mod is loaded.
        /// <br/>Happens when the mod is Registered in <see cref="IBattlesController"/>
        /// </summary>
        void Start();

        /// <summary>
        /// Called once every tick
        /// </summary>
        /// <remarks>This is a pseudo-Update method. Not actually synced to Battles's tick</remarks>
        void Update();
    }
}